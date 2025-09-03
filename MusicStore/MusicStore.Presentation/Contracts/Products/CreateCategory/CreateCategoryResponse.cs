namespace MusicStore.Presentation.Contracts.Products.CreateCategory
{
    public class CreateCategoryResponse
    {
        public Guid CategoryId { get; }

        public CreateCategoryResponse( Guid categoryId )
        {
            CategoryId = categoryId;
        }
    }
}
