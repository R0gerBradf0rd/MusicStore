using MusicStore.Application.Interfaces.Command;
using MusicStore.Application.Results;
using MusicStore.Domain.Entities.Products;

namespace MusicStore.Application.Products.Commands.CreateProduct
{
    public class CreateProductCommand : ICommand<Result<Guid>>
    {
        public string Name { get; }

        public string Description { get; }

        public decimal Price { get; }

        public string PriceCurrencyCode { get; }

        public string ImageURL { get; }

        public Guid ProductTypeId { get; }

        public ICollection<ProductTag> ProductTags { get; }

        public CreateProductCommand(
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
