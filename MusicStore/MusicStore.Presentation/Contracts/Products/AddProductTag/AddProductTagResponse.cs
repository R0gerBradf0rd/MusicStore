namespace MusicStore.Presentation.Contracts.Products.AddProductTag
{
    public class AddProductTagResponse
    {
        public Guid TagId { get; }

        public Guid ProductId { get; }

        public AddProductTagResponse( Guid tagId, Guid productId )
        {
            TagId = tagId;
            ProductId = productId;
        }
    }
}
