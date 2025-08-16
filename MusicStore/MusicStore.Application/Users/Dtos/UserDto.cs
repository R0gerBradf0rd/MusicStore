namespace MusicStore.Application.Users.Dtos
{
    public class UserDto
    {
        public string Name { get; }

        public string Email { get; }

        public UserDto( string name, string email )
        {
            Name = name;
            Email = email;
        }
    }
}
