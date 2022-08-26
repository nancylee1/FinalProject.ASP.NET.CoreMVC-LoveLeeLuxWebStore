using LoveLeeLux.Models;
using Microsoft.AspNetCore.Mvc;

namespace LoveLeeLux.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductRepository repo;
        private readonly IWebHostEnvironment _hostEnvironment;

        public ProductController(IProductRepository repo, IWebHostEnvironment hostEnvironment)
        {
            this.repo = repo;
            this._hostEnvironment = hostEnvironment;
        }


        public IActionResult Index()
        {
            return View(repo.GetAllProducts());
        }

        public IActionResult ViewProduct(int id)
        {
            var product = repo.GetProduct(id);
            return View(product);
        }

        public IActionResult UpdateProduct(int id)
        {
            Product prod = repo.GetProduct(id);
            if (prod == null)
            {
                return View("ProductNotFound");
            }
            return View(prod);
        }
        public IActionResult UpdateProductToDatabase(Product product)
        {
            repo.UpdateProduct(product);

            return RedirectToAction("ViewProduct", new { id = product.ProductID });
        }

        public IActionResult InsertProduct()  // InsertProduct()
        {
            var prod = repo.AssignCategory();
            return View(prod);
        }

        public async Task<IActionResult> InsertProductToDatabase(Product productToInsert)  // InsertProductToDatabase()
        {
            repo.InsertProduct(productToInsert);
            if (productToInsert.ImageUpload != null)//its required anyways but error proof
            {
                int newID = repo.GetProductID(productToInsert.Name);
                string wwwRootPath = _hostEnvironment.WebRootPath;
                string extension = Path.GetExtension(productToInsert.ImageUpload.FileName);
                var absolutePath = wwwRootPath + "/images/" + newID + extension;
                using (var fileStream = new FileStream(absolutePath, FileMode.Create))
                {
                    await productToInsert.ImageUpload.CopyToAsync(fileStream);
                }
            }
            return RedirectToAction("Index");
        }
        public IActionResult DeleteProduct(Product product) // DeleteProduct
        {

            repo.DeleteProduct(product);
            var relativePath = "/images/" + product.ProductID + ".png";
            string wwwRootPath = _hostEnvironment.WebRootPath;
            var absolutePath = wwwRootPath + relativePath;
            if (System.IO.File.Exists(absolutePath))
            {
                System.IO.File.Delete(absolutePath);
            }
            return RedirectToAction("Index");
        }

        public IActionResult ProductSearch(string SearchProduct)
        {
            var filteredProducts = repo.GetSearchedProducts(SearchProduct);
            return View(filteredProducts);
        }
    }
}
