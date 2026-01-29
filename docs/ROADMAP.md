# Taskify Roadmap

## Phase 0 — Scaffold (Done)

- [x] Backend: ASP.NET Core Web API + Swagger
- [x] Endpoints: `/` and `/health`
- [x] Frontend: React + TypeScript (Vite)

## Phase 1 — Core Kanban (Next)

- [ ] Data model: Project → Board → Column → Card
- [ ] CRUD APIs for:
  - [ ] Projects
  - [ ] Boards
  - [ ] Columns
  - [ ] Cards
- [ ] Frontend UI:
  - [ ] Projects list
  - [ ] Boards list
  - [ ] Board view (columns + cards)

## Phase 2 — Persistence

- [ ] Add EF Core + Database (PostgreSQL or SQL Server)
- [ ] Migrations
- [ ] Seed sample data
- [ ] Basic validation + error handling

## Phase 3 — Quality & UX

- [ ] Search / filter
- [ ] Pagination (where needed)
- [ ] Logging + global exception handling
- [ ] CORS + config cleanup

## Phase 4 — Auth (Later)

- [ ] JWT Authentication
- [ ] Users + Workspaces
- [ ] Role/permissions (optional)

## Phase 5 — Deployment (Later)

- [ ] Docker (API + Web)
- [ ] CI workflow
- [ ] Deploy (Azure / Render / Railway)
