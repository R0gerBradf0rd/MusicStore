namespace MusicStore.Presentation.Contracts.Products.CreateProduct
{
    public class CreateProductResponse
    {
        public Guid ProductId { get; }

        public CreateProductResponse( Guid productId )
        {
            ProductId = productId;
        }
    }
}
