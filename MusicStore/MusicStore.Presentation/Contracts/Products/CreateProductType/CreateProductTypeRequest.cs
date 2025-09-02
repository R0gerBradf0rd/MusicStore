namespace MusicStore.Presentation.Contracts.Products.CreateProductType
{
    public class CreateProductTypeRequest
    {
        public string Name { get; }

        public Guid CategoryId { get; }

        public CreateProductTypeRequest( string name, Guid categoryId )
        {
            Name = name;
            CategoryId = categoryId;
        }
    }
}
