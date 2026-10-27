using Productos.Api.Services;

namespace Productos.Api.Endpoints;

public static class ProductoEndpoints
{
    public static IEndpointRouteBuilder MapProductoEndpoints(this IEndpointRouteBuilder endpoints)
    {
        var productos = endpoints.MapGroup("/api/productos");

        productos.MapGet("/", (IProductoService service) => Results.Ok(service.GetAll()));
        productos.MapGet("/{id:int}", (int id, IProductoService service) =>
        {
            var producto = service.GetById(id);
            return producto is null ? Results.NotFound() : Results.Ok(producto);
        });

        return endpoints;
    }
}
