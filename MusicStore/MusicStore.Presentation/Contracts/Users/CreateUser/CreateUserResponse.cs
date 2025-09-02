namespace MusicStore.Presentation.Contracts.Users.CreateUser
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
