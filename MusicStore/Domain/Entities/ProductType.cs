namespace MusicStore.Domain.Entities
{
    public class ProductType
    {
        public Guid Id { get; }

        public string Name { get; }

        public Guid CatergoryId { get; }
    }
}
