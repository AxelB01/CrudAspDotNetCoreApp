using CrudAspDotNetCoreApp.Models;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using Dapper;
using System.Data;

namespace CrudAspDotNetCoreApp.Data
{
    public class ProductosDataService : IProductosDataService
    {
        private readonly IConfiguration _configuration;

        public ProductosDataService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public void CreateProducto(Producto producto)
        {
            var connectionString = _configuration.GetConnectionString("DBConnection");
            var parameters = new
            {
                nombre = producto.Nombre,
                categoria = producto.Categoria,
                pCompra = producto.PrecioCompra,
                pVenta = producto.PrecioVenta,
                comentario = producto.Comentario
            };
            using (var conn = new SqlConnection(connectionString))
            {
                conn.Execute("CreateProducto", parameters, commandType: CommandType.StoredProcedure);
            }
        }

        public void DeleteProducto(int idProducto)
        {
            var connectionString = _configuration.GetConnectionString("DBConnection");
            using (var conn = new SqlConnection(connectionString))
            {
                conn.Execute("DeleteProductoById", new { idProducto }, commandType: CommandType.StoredProcedure);
            }
        }

        public Producto GetProductoById(int idProducto)
        {
            var connectionString = _configuration.GetConnectionString("DBConnection");
            using (var conn = new SqlConnection(connectionString))
            {
                var result = conn.QuerySingle<Producto>("GetProductoById", new { idProducto }, commandType: CommandType.StoredProcedure);
                return result;
            }
        }

        public void UpdateProductoById(Producto producto)
        {
            var connectionString = _configuration.GetConnectionString("DBConnection");
            var parameters = new
            {
                idProducto = producto.IdProducto,
                nombre = producto.Nombre,
                categoria = producto.Categoria,
                pCompra = producto.PrecioCompra,
                pVenta = producto.PrecioVenta,
                comentario = producto.Comentario
            };
            using (var conn = new SqlConnection(connectionString))
            {
                conn.Execute("UpdateProductoById", parameters, commandType: CommandType.StoredProcedure);
            }
        }

        public IEnumerable<Producto> GetProductos()
        {
            var connectionString = _configuration.GetConnectionString("DBConnection");
            using (var conn = new SqlConnection(connectionString))
            {
                var result = conn.Query<Producto>("GetProductos", commandType: CommandType.StoredProcedure);
                return result;
            }
        }
    }
}
