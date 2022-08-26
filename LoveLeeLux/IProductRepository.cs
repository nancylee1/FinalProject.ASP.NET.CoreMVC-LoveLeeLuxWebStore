using LoveLeeLux.Models;

namespace LoveLeeLux
{
    public interface IProductRepository
    {
        public IEnumerable<Product> GetAllProducts();  // all products
        public Product GetProduct(int id);// to View one product at a time, add a new stubbed out method- GetProduct() - to the IProductRepository Interface
        public void UpdateProduct(Product product);// Now that we can view an individual product, let’s give the user the ability to make updates to that product: add the UpdateProduct stubbed out Method
        public void InsertProduct (Product productToInsert); // " to Create a product, InsertProduct() = Inside of the IProductRepository interface add these 3 methods "
        public IEnumerable<Category> GetCategories(); // " GetCategories()
        public Product AssignCategory(); // " AssignCategory()
        public void DeleteProduct(Product product); // Delete product

        public IEnumerable<Product> GetSearchedProducts(string SearchProduct);
        public int GetProductID(string productName);
    }
}
