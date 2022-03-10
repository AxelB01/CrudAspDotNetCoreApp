using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CrudAspDotNetCoreApp.Models
{
    public class Producto
    {
        [Display(Name = "Código")]
        public int IdProducto { get; set; }
        [Required(ErrorMessage = "Debe ingresar el nombre del producto")]
        public string Nombre { get; set; }
        [Required(ErrorMessage = "Debe ingresar la categoría del producto")]
        public string Categoria { get; set; }
        [Required(ErrorMessage = "Debe ingresar un precio de compra")]
        [Display(Name = "Precio de compra")]
        public decimal PrecioCompra { get; set; }
        [Required(ErrorMessage = "Debe ingresar un precio de venta")]
        [Display(Name = "Precio de venta")]
        public decimal PrecioVenta { get; set; }
        public string Comentario { get; set; }
    }
}
