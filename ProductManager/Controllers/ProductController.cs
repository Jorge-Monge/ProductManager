using Microsoft.AspNetCore.Mvc;
using ProductManager.Models;
using ProductManager.Services;

namespace ProductManager.Controllers
{

    public class ProductController : Controller
    {

        public IActionResult Index(ProductModel createdProduct)
        {
            // Example getting the data locally
            //HardCodedSampleDataRepository dataRepo = new HardCodedSampleDataRepository();

            // Example getting the data from a SQL Server DB
            SqlConnector sqlConnector = new SqlConnector();

            return View(sqlConnector.GetAllProducts());
        }

        public IActionResult Search()
        {
            return View();
        }

        public IActionResult SearchResult(string searchTerm)
        {
            //HardCodedSampleDataRepository dataRepo = new HardCodedSampleDataRepository();

            // Example getting the data from a SQL Server DB
            SqlConnector sqlConnector = new SqlConnector();

            return View("Index", sqlConnector.SearchProducts(searchTerm));
        }

        //public IActionResult Create()
        //{
        //    int nextProductId = productsList.Count + 1;
        //    return View(new ProductModel() { Id = nextProductId});
        //}

        //public IActionResult Details(ProductModel product)
        //{
        //    // If we are coming from the 'Create' controller, the 'product' won't
        //    // exist in the 'productsList' yet
        //    if (!productsList.Any(item => item.Id == product.Id)) {
        //        productsList.Add(product);
        //    }

        //    // But if the 'product' is already in the 'productsList'
        //    // that means that we simply want to examine the details of an existing product
        //    return View(product);
        //}


    }
}
