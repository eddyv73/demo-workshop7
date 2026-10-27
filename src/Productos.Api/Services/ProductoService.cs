using Productos.Api.Models;

namespace Productos.Api.Services;

public class ProductoService : IProductoService
{
    private static readonly IReadOnlyList<Producto> Productos =
    [
        new(1, "Teclado", 49.99m),
        new(2, "Ratón", 24.50m),
        new(3, "Monitor", 199.00m)
    ];

    public IReadOnlyList<Producto> GetAll() => Productos;

    public Producto? GetById(int id) => Productos.FirstOrDefault(producto => producto.Id == id);
}
