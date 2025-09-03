namespace MusicStore.Presentation.Contracts.Products.CreateTag
{
    public class CreateTagRequest
    {
        public string Value { get; }

        public CreateTagRequest( string value )
        {
            Value = value;
        }
    }
}
