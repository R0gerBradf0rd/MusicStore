namespace MusicStore.Presentation.Contracts.Carts.SetCartItemSelectionStatus
{
    public class SetCartItemSelectionStatusResponse
    {
        public string Result { get; }

        public SetCartItemSelectionStatusResponse( string result )
        {
            Result = result;
        }
    }
}
