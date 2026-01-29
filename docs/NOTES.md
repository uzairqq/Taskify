# Taskify Notes

## 2026-01-29

### Done

- Created backend ASP.NET Core Web API (cleaned template)
- Added endpoints:
  - `/` -> "Taskify API is running"
  - `/health` -> `{ status: "ok" }`
- Created frontend React + TypeScript app using Vite + SWC
- Repo organized as monorepo: `backend/`, `frontend/`, `docs/`

### Next

- Add CORS configuration (to allow frontend -> backend)
- Create first real API module: Projects (CRUD)
- Create basic frontend page to list Projects
- Add EF Core + database (later)
