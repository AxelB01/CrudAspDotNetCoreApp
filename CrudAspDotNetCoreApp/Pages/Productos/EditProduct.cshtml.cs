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
    public class EditProductModel : PageModel
    {
        private readonly IProductosDataService _productosDataService;

        public EditProductModel(IProductosDataService productosDataService)
        {
            _productosDataService = productosDataService;
        }

        [BindProperty]
        public Producto Producto { get; set; }
        public string ErrorMessage { get; set; }

        public void OnGet()
        {
            int idProducto = int.Parse(Request.Query["idProducto"].ToString());
            Producto = _productosDataService.GetProductoById(idProducto);
        }

        public IActionResult OnPost()
        {
            try
            {
                _productosDataService.UpdateProductoById(Producto);
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
