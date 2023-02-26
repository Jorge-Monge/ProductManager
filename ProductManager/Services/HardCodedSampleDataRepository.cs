using Bogus;
using ProductManager.Models;

namespace ProductManager.Services
{
    public class HardCodedSampleDataRepository : IProductDataService
    {
        static List<ProductModel> productsList = new List<ProductModel>();

        public HardCodedSampleDataRepository()
        {

            if (productsList.Count == 0)
            {
                for (int i = 1; i <= 100; i++)
                {
                    productsList.Add(new Faker<ProductModel>()
                        .RuleFor(p => p.Id, i)
                        .RuleFor(p => p.Name, f => f.Commerce.ProductName())
                        .RuleFor(p => p.Price, f => f.Commerce.Random.Decimal(100))
                        .RuleFor(p => p.Description, f => f.Rant.Review())
                        );
                }
            }
        }

        public int Delete(ProductModel product)
        {
            throw new NotImplementedException();
        }

        public List<ProductModel> GetAllProducts()
        {
            return productsList;
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
            return productsList.FindAll(p => {
                if (p.Name is not null && p.Name != "" )
                {
                    return p.Name.ToLower().Contains(searchTerm.ToLower());
                }
                return false;
                });
        }

        public int Update(ProductModel product)
        {
            throw new NotImplementedException();
        }
    }
}
