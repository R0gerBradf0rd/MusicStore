namespace MusicStore.Application.Interfaces
{
    public interface IRepository<T>
    {
        Task AddAsync( T entity );

        Task UpdateAsync( T entity );

        Task DeleteAsync( T entity );

        Task<T?> GetByIdAsync( Guid id );
    }
}
