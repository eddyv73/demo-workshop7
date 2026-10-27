# Arquitectura

- `Endpoints/` agrupa las rutas HTTP por recurso y delega el trabajo en servicios.
- `Models/` contiene los tipos de datos que usa la API.
- `Services/` define contratos y lógica de acceso a datos; aquí los datos son fijos y en memoria.
- `Program.cs` registra dependencias y conecta los grupos de endpoints.
- `tests/` contiene pruebas HTTP para comprobar las respuestas de la API.
