namespace MusicStore.Presentation.Contracts.Products.CreateTag
{
    public class CreateTagResponse
    {
        public Guid TagId { get; }

        public CreateTagResponse( Guid tagId )
        {
            TagId = tagId;
        }
    }
}
