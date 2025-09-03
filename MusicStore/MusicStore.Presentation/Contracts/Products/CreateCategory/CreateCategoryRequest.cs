namespace MusicStore.Presentation.Contracts.Products.CreateCategory
{
    public class CreateCategoryRequest
    {
        public string Name { get; }

        public CreateCategoryRequest( string name )
        {
            Name = name;
        }
    }
}
