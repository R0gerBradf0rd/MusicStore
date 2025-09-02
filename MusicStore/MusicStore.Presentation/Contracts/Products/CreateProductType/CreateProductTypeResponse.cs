namespace MusicStore.Presentation.Contracts.Products.CreateProductType
{
    public class CreateProductTypeResponse
    {
        public Guid ProductTypeId { get; }

        public CreateProductTypeResponse( Guid productTypeId )
        {
            ProductTypeId = productTypeId;
        }
    }
}
