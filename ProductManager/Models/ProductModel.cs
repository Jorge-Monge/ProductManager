using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ProductManager.Models
{
    public class ProductModel
    {
        public int Id { get; set; }

        [DisplayName("Product Name")]
        public string? Name { get; set; }

        [DataType(DataType.Currency)]
        [DisplayName("Price in USD")]
        public decimal Price { get; set; }

        public string? Description { get; set; }

    }
}
