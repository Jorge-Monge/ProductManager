using ProductManager.Models;
using System.Data.SqlClient;
using System.Diagnostics;

namespace ProductManager.Services
{
    public class SqlConnector : IProductDataService
    {
        string connString = @"Data Source = (localdb)\MSSQLLocalDB; Initial Catalog = Test; Integrated Security = True; Connect Timeout = 30; Encrypt = False; TrustServerCertificate = True;";
        List<ProductModel> products = new List<ProductModel>();

        public int Delete(ProductModel product)
        {
            throw new NotImplementedException();
        }
        public List<ProductModel> GetAllProducts()
        {
            string sql = "SELECT * FROM dbo.products";

            using (SqlConnection connection = new SqlConnection(connString))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            products.Add(new ProductModel()
                            {
                                Id = (int)reader.GetValue(0),
                                Name = reader.GetValue(1).ToString(),
                                Price = (decimal)reader.GetValue(2),
                                Description = reader.GetValue(3).ToString()
                            });
                        }
                    }
                }
            }

            return products;
        }

        public ProductModel GetProductById(int id)
        {
            throw new NotImplementedException();
        }
        public int Insert(ProductModel product)
        {
            throw new NotImplementedException();
        }

        public List<ProductModel> SearchProducts(string searchTerm)
        {
            //return products.FindAll(p => p.Name.ToLower().Contains(searchTerm.ToLower()));

            string sql = "SELECT * FROM dbo.products WHERE LOWER(Name) LIKE @name";
            Debug.WriteLine($"SQL QUERY: {sql}");

            using (SqlConnection connection = new SqlConnection(connString))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    command.Parameters.AddWithValue("@name", $"%{searchTerm}%");
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            products.Add(new ProductModel()
                            {
                                Id = (int)reader.GetValue(0),
                                Name = reader.GetValue(1).ToString(),
                                Price = (decimal)reader.GetValue(2),
                                Description = reader.GetValue(3).ToString()
                            });
                        }
                    }
                }
            }

            return products;
        }

        public int Update(ProductModel product)
        {
            throw new NotImplementedException();
        }
    }
}
