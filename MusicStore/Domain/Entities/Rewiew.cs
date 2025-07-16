namespace MusicStore.Domain.Entities
{
    public class Rewiew
    {
        public Guid Id { get; }

        public Guid ProductId { get; }

        public Guid UserId { get; }

        public int Raiting { get; }

        public string Description { get; }
    }
}
