using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CrudAspDotNetCoreApp.Data;
using CrudAspDotNetCoreApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CrudAspDotNetCoreApp.Pages.Productos
{
    public class DeleteProductModel : PageModel
    {
        private readonly IProductosDataService _productosDataService;

        public DeleteProductModel(IProductosDataService productosDataService)
        {
            _productosDataService = productosDataService;
        }

        [BindProperty]
        public Producto Producto { get; set; }
        public string ErrorMessage { get; set; }

        public void OnGet(int idProducto)
        {
            Producto = _productosDataService.GetProductoById(idProducto);
        }

        public IActionResult OnPost(int idProducto)
        {
            try
            {
                _productosDataService.DeleteProducto(idProducto);
                return RedirectToPage("Index");
            }
            catch (Exception e)
            {
                ErrorMessage = e.Message;
                return Page();
            }
        }
    }
}
