# Productos API

API web mínima en C# con .NET 10. Devuelve tres productos de ejemplo en memoria.

## Ejecutar

```bash
dotnet run --project src/Productos.Api
```

La API ofrece `GET /api/productos`, `GET /api/productos/{id}` y `GET /health`. Un producto inexistente responde con `404`.

## Pruebas

```bash
dotnet test Productos.sln
```

## Estructura

- `src/Productos.Api/Endpoints/`: rutas agrupadas por recurso.
- `src/Productos.Api/Models/`: modelos de datos.
- `src/Productos.Api/Services/`: interfaces y lógica/datos de ejemplo.
- `tests/Productos.Api.Tests/`: pruebas HTTP con xUnit.
- `docs/arquitectura.md`: responsabilidades de las carpetas.