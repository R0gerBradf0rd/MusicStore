namespace MusicStore.Presentation.Contracts.Products.RemoveProductTag
{
    public class RemoveProductTagResponse
    {
        public Guid TagId { get; }

        public Guid ProductId { get; }

        public RemoveProductTagResponse( Guid tagId, Guid productId )
        {
            TagId = tagId;
            ProductId = productId;
        }
    }
}
