using Productos.Api.Models;

namespace Productos.Api.Services;

public interface IProductoService
{
    IReadOnlyList<Producto> GetAll();

    Producto? GetById(int id);
}
