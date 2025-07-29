namespace MusicStore.Application.Interfaces.Repository
{
    public interface IRepository<T>
    {
        Task AddAsync( T entity );

        Task UpdateAsync( T entity );

        Task DeleteAsync( T entity );
    }
}
