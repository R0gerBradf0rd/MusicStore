namespace MusicStore.Application.Interfaces.UnitOfWork
{
    public interface IUnitOfWork
    {
        Task CommitAsync();
    }
}
