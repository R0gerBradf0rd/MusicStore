using MusicStore.Domain.Entities.Products;

namespace MusicStore.Presentation.Contracts.Products.GetProduct
{
    public class GetProductResponse
    {
        public string Name { get; }

        public string Description { get; }

        public decimal Price { get; }

        public string PriceCurrencyCode { get; }

        public string ImageURL { get; }

        public ICollection<ProductTag> ProductTags { get; }

        public GetProductResponse(
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
