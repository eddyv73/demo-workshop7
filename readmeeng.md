# Products API

A minimal web API in C# with .NET 10. It returns three sample products stored in memory.

## Project description

This project is intended to demonstrate how GitHub Copilot works.

## Run

```bash
dotnet run --project src/Productos.Api
```

The API provides `GET /api/productos`, `GET /api/productos/{id}`, and `GET /health`. A product that does not exist returns `404`.

## Tests

```bash
dotnet test Productos.sln
```

## Structure

- `src/Productos.Api/Endpoints/`: routes grouped by resource.
- `src/Productos.Api/Models/`: data models.
- `src/Productos.Api/Services/`: interfaces and example logic/data.
- `tests/Productos.Api.Tests/`: HTTP tests with xUnit.
- `docs/arquitectura.md`: folder responsibilities.
