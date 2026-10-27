using Productos.Api.Endpoints;
using Productos.Api.Services;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddSingleton<IProductoService, ProductoService>();

var app = builder.Build();
app.MapProductoEndpoints();
app.MapHealthEndpoints();
app.Run();
