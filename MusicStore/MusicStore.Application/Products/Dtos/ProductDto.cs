using MusicStore.Domain.Entities.Products;

namespace MusicStore.Application.Products.Dtos
{
    public class ProductDto
    {
        public string Name { get; }

        public string Description { get; }

        public decimal Price { get; }

        public string PriceCurrencyCode { get; }

        public string ImageURL { get; }

        public ICollection<ProductTag> ProductTags { get; }

        public ProductDto(
            string name,
            string description,
            decimal price,
            string priceCurrencyCode,
            string imageURL,
            ICollection<ProductTag> productTags )
        {
            Name = name;
            Description = description;
            Price = price;
            PriceCurrencyCode = priceCurrencyCode;
            ImageURL = imageURL;
            ProductTags = productTags;
        }
    }
}
