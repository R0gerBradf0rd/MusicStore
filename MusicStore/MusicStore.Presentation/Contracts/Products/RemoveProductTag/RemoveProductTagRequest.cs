namespace MusicStore.Presentation.Contracts.Products.RemoveProductTag
{
    public class RemoveProductTagRequest
    {
        public Guid TagId { get; }

        public Guid ProductId { get; }

        public RemoveProductTagRequest( Guid tagId, Guid productId )
        {
            TagId = tagId;
            ProductId = productId;
        }
    }
}
