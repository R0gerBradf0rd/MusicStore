namespace MusicStore.Presentation.Contracts.Users
{
    public class GetUserResponse
    {
        public string Name { get; }

        public string Email { get; }

        public GetUserResponse( string name, string email )
        {
            Name = name;
            Email = email;
        }
    }
}
