using MusicStore.Domain.Entities.Products;
using MusicStore.Presentation.Contracts.Products.AddProductTag;

namespace MusicStore.Presentation.Contracts.Products.CreateProduct
{
    public class CreateProductRequest
    {
        public string Name { get; }

        public string Description { get; }

        public decimal Price { get; }

        public string PriceCurrencyCode { get; }

        public string ImageURL { get; }

        public Guid ProductTypeId { get; }

        public ICollection<ProductTag> ProductTags { get; }

        public CreateProductRequest(
            string name,
            string description,
            decimal price,
            string priceCurrencyCode,
            string imageURL,
            Guid productTypeId,
            ICollection<ProductTag> productTags )
        {
            Name = name;
            Description = description;
            Price = price;
            PriceCurrencyCode = priceCurrencyCode;
            ImageURL = imageURL;
            ProductTypeId = productTypeId;
            ProductTags = productTags;
        }
    }
}
