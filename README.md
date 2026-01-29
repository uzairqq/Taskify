# Taskify (Monorepo) – Full-stack Task Management

Taskify is a Kanban-style task manager (Projects → Boards → Columns → Cards).
This repo is a monorepo with an ASP.NET Core Web API backend and a React + TypeScript frontend.

## Tech Stack

- Backend: ASP.NET Core Web API (.NET), Swagger/OpenAPI
- Frontend: React + TypeScript (Vite + SWC)

## Repo Structure

- `backend/Taskify.Api` – Web API
- `frontend/taskify-web` – React app
- `docs/` – roadmap, decisions, notes

## Run Backend

Open `backend/Taskify.Api` in Visual Studio and Run (https).
Swagger: `https://localhost:7275/swagger`

## Run Frontend

```bash
cd frontend/taskify-web
npm install
npm run dev
```
