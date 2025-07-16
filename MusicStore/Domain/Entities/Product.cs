namespace MusicStore.Domain.Entities
{
    public class Product
    {
        public Guid Id { get; }

        public string Name { get; }

        public string Description { get; }

        public double Price { get; }

        public string ImageURL { get; }

        public Guid ProductTypeId { get; } 
    }
}
