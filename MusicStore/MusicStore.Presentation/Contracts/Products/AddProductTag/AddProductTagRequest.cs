namespace MusicStore.Presentation.Contracts.Products.AddProductTag
{
    public class AddProductTagRequest
    {
        public Guid TagId { get; }

        public Guid ProductId { get; }

        public AddProductTagRequest( Guid tagId, Guid productId )
        {
            TagId = tagId;
            ProductId = productId;
        }
    }
}
