using Dapper;
using LoveLeeLux.Models;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace LoveLeeLux
{
    public class ProductRepository: IProductRepository
    {
        private readonly IDbConnection _conn;
        public ProductRepository(IDbConnection conn) // Setup the constructor so that it will accept an IDbConnection as an argument and store that argument in _conn:
        {
            _conn = conn;
        }

        //GetAllProducts method will utilize Dapper to query LoveLeeLux database & return a collection of Product - IEnumerable<Product>
        public IEnumerable<Product> GetAllProducts()
        {
            return _conn.Query<Product>("SELECT * FROM PRODUCTS;");
        }

        public Product GetProduct(int id) // calling a single item from the products list. We will use the QuerySingle Dapper method so that we can return a single row
        {
            return _conn.QuerySingle<Product>("SELECT * FROM PRODUCTS WHERE PRODUCTID = @id", new { id = id });
        }

        public void UpdateProduct(Product product) // Create the UpdateProduct() ProductRepository Method Implementation:
        {
            _conn.Execute("UPDATE products SET Name = @name, Price = @price, Description = @description WHERE ProductID = @id", new { name = product.Name, price = product.Price, description = product.Description, id = product.ProductID });
        }

        public void InsertProduct(Product productToInsert)  // InsertProduct()
        {
            _conn.Execute("INSERT INTO products (NAME, PRICE, DESCRIPTION, CATEGORYID) VALUES (@name, @price, @description, @categoryID);",
                new { name = productToInsert.Name, price = productToInsert.Price, description = productToInsert.Description, categoryID = productToInsert.CategoryID });
        }

        public IEnumerable<Category> GetCategories() // GetCategories()
        {
            return _conn.Query<Category>("SELECT * FROM categories;");
        }

        public Product AssignCategory() // AssignCategory()
        {
            var categoryList = GetCategories();
            var product = new Product();
            product.Categories = categoryList;
            return product;
        }

        public void DeleteProduct(Product product)
        {
            _conn.Execute("DELETE FROM REVIEWS WHERE ProductID = @id;", new { id = product.ProductID });
            _conn.Execute("DELETE FROM Sales WHERE ProductID = @id;", new { id = product.ProductID });
            _conn.Execute("DELETE FROM Products WHERE ProductID = @id;", new { id = product.ProductID });
        }

        public IEnumerable<Product> GetSearchedProducts(string SearchProduct)
        {
            return _conn.Query<Product>($"SELECT * FROM Products where name LIKE '%{SearchProduct}%';");
        }
        public int GetProductID(string productName)
        {
            var product = _conn.QuerySingle<Product>($"SELECT * FROM Products WHERE Name = '{productName}';");
            return product.ProductID;
        }
    }
}
