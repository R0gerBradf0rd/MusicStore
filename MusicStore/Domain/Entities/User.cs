namespace MusicStore.Domain.Entities
{
    public class User
    {
        public Guid Id { get; }

        public string Name { get; }

        public string Email { get; }

        public string ShippingAddress { get; }

        public string Role { get; }
    }
}
