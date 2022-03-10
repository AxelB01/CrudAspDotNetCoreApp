using CrudAspDotNetCoreApp.Models;
using System.Collections.Generic;

namespace CrudAspDotNetCoreApp.Data
{
    public interface IProductosDataService
    {
        IEnumerable<Producto> GetProductos();
        Producto GetProductoById(int idProducto);
        void UpdateProductoById(Producto producto);
        void CreateProducto(Producto producto);
        void DeleteProducto(int idProducto);
    }
}