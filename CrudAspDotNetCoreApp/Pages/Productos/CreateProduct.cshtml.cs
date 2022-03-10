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
    public class CreateProductModel : PageModel
    {
        private readonly IProductosDataService _productosDataService;

        public CreateProductModel(IProductosDataService productosDataService)
        {
            _productosDataService = productosDataService;
        }

        [BindProperty]
        public Producto Producto { get; set; }
        public string ErrorMessage { get; set; }

        public void OnGet()
        {

        }

        public IActionResult OnPost(Producto producto)
        {
            try
            {
                _productosDataService.CreateProducto(producto);
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
