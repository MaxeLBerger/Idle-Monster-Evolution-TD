# Supabase Setup

This document outlines how to create and configure the Supabase project for Idle Monster Evolution TD. It focuses on auth, cloud save, and remote config while keeping credentials out of the codebase.

## Prerequisites
- Supabase account with workspace access.
- GitHub repository `MaxeLBerger/Idle-Monster-Evolution-TD`.
- Environment management via `.env` using the keys declared in `.env.example`.

## Project Creation
1. Create a new Supabase project in the desired region.
2. Note the `SUPABASE_URL` and `SUPABASE_ANON_KEY` from Project Settings → API.
3. Generate a `SERVICE_ROLE_KEY` (server-side only); do not use this in the client.

## Environment Variables
Populate a local `.env` (not committed) with:

```
SUPABASE_URL=your-project-url
SUPABASE_ANON_KEY=your-anon-key
SUPABASE_SERVICE_ROLE_KEY=your-service-role-key
REMOTE_CONFIG_BUCKET=idle-monster-config
ANALYTICS_WRITE_KEY=your-analytics-key
BUILD_CHANNEL=dev
```

Ensure production uses different values with a secure delivery mechanism (e.g., GitHub Actions secrets).

## Schemas & Tables
- `auth.users`: managed by Supabase Auth.
- `cloud_save`: stores per-user game state snapshots.
  - Columns: `id` (uuid), `user_id` (uuid), `version` (int), `payload` (jsonb), `updated_at` (timestamptz).
  - Index on `user_id`, unique on `(user_id, version)`.
- `remote_config`: key-value store for feature flags/config.
  - Columns: `key` (text), `value` (jsonb), `updated_at` (timestamptz), `env` (text: dev/stage/prod).
  - Primary key `(key, env)`.

## RLS Policies
Enable Row Level Security and add policies:
- `cloud_save`: users can select/insert/update rows where `user_id = auth.uid()`.
- `remote_config`: read-only for all clients; writes allowed only via service role.

## API Access Patterns
- Client reads/writes `cloud_save` using anon key with RLS protections.
- Client reads `remote_config` with anon key.
- Server-side jobs (CI, admin tools) use `SERVICE_ROLE_KEY` for writing remote config or migrations.

## Conflict Resolution Strategy (Cloud Save)
- Use monotonic `version` increments.
- On write, fetch latest version; if local version < latest, prompt merge or accept latest.
- Persist minimal diffs when possible to reduce payload size.

## Analytics
- Do not send PII. Use anonymized user IDs.
- Events: session start/end, wave start/end, summon, purchases, ad views.

## Security Notes
- Never commit real keys.
- Use GitHub Actions secrets for CI/CD.
- Rotate keys on compromise; update `.env` and secrets.

## Next Steps
- Create simple admin scripts for seeding `remote_config`.
- Integrate Unity client via service interfaces (`ICloudSaveService`, `IRemoteConfigService`).
