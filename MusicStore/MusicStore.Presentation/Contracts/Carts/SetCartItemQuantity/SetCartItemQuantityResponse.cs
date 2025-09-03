namespace MusicStore.Presentation.Contracts.Carts.SetCartItemQuantity
{
    public class SetCartItemQuantityResponse
    {
        public string Result { get; }

        public SetCartItemQuantityResponse( string result )
        {
            Result = result;
        }
    }
}
