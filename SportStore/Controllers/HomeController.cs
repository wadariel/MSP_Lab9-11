using Microsoft.AspNetCore.Mvc;
using SportStore.Models;
using SportStore.Models.ViewModels;
using System.ComponentModel;
using System.Diagnostics;

namespace SportStore.Controllers
{
    public class HomeController : Controller
    {
        private IStoreRepositiry repositiry;

        public HomeController(IStoreRepositiry repositiry)
        {
            this.repositiry = repositiry;
        }

        public int PageSize = 4;

        public ViewResult Index(string category, int productPage = 1)
        {
            return View(new ProductsListViewModel
            {
                Products = repositiry.Products
                    .Where(p => category == null || p.Category == category)
                    .OrderBy(p => p.ProductID) 
                    .Skip((productPage - 1) * PageSize) 
                    .Take(PageSize), 
                PaginInfo = new PaginInfo
                {
                    CurrentPage = productPage, 
                    ItemsPerPage = PageSize, 
                    TotalItems = repositiry.Products.Count() 
                }
            });
        }

        
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}

