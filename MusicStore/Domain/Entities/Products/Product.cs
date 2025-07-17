namespace MusicStore.Domain.Entities.Products
{
    public class Product
    {
        public Guid Id { get; }

        public string Name { get; }

        public string Description { get; }

        public decimal Price { get; }

        public string PriceCurrencyCode { get; }

        public string ImageURL { get; }

        public Guid ProductTypeId { get; }
    }
}