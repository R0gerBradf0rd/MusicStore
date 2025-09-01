namespace MusicStore.Presentation.Contracts.Users
{
    public class CreateUserResponse
    {
        public Guid UserId { get; }

        public CreateUserResponse( Guid userId )
        {
            UserId = userId;
        }
    }
}
