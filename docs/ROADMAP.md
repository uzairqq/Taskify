# Taskify Roadmap (Job-First)

## Phase 1 — MVP Backend (Priority)

- [ ] Create backend solution + project structure (Api/Domain/Application/Infrastructure)
- [ ] Task entity + TaskStatus enum (Todo/InProgress/Done)
- [ ] DTOs + validation (CreateTask, UpdateTask)
- [ ] Tasks CRUD endpoints
  - [ ] GET /api/tasks
  - [ ] GET /api/tasks/{id}
  - [ ] POST /api/tasks
  - [ ] PUT /api/tasks/{id}
  - [ ] DELETE /api/tasks/{id}
- [ ] EF Core + PostgreSQL integration
- [ ] Migrations + seed data
- [ ] Pagination (page, pageSize)
- [ ] Search (by title) + filter (by status)
- [ ] Swagger documentation cleanup

## Phase 2 — Basic Frontend

- [ ] Vite + React + TypeScript setup
- [ ] Task list UI + create/edit form
- [ ] Status filter + search
- [ ] API integration (fetch/axios)

## Phase 3 — Interview/Production polish

- [ ] Global exception handling middleware
- [ ] Logging (structured)
- [ ] Unit tests (xUnit)
- [ ] Docker compose (API + DB)
- [ ] CI (GitHub Actions)
- [ ] Auth (JWT) (optional)
