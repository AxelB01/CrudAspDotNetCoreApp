using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CrudAspDotNetCoreApp.Data;
using CrudAspDotNetCoreApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace CrudAspDotNetCoreApp.Pages.Productos
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly IProductosDataService _productosDataService;

        public IndexModel(ILogger<IndexModel> logger, IProductosDataService productosDataService)
        {
            _logger = logger;

            _productosDataService = productosDataService;
        }

        public IEnumerable<Producto> Productos { get; set; }

        public void OnGet()
        {
            Productos = _productosDataService.GetProductos();
        }

    }
}
