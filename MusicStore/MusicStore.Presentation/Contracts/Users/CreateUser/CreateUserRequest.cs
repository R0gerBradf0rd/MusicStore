namespace MusicStore.Presentation.Contracts.Users.CreateUser
{
    public class CreateUserRequest
    {
        public string Name { get; }

        public string Email { get; }

        public string Role { get; }

        public CreateUserRequest( string name, string email, string role )
        {
            Name = name;
            Email = email;
            Role = role;
        }
    }
}
