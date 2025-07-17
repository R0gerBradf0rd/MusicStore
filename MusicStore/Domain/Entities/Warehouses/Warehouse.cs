namespace MusicStore.Domain.Entities.Warehouses
{
    /// <summary>
    /// Представляет склад, на котором содержатся товары
    /// </summary>
    public class Warehouse
    {
        /// <summary>
        /// Создает склад, на котором содержатся товары, с указанным идентификатором
        /// </summary>
        /// <param name="address">Адрес склада</param>
        /// <exception cref="ArgumentNullException">Если переданное значение параметра пустое</exception>
        public Warehouse( string address )
        {
            if ( address is null )
            {
                throw new ArgumentNullException( "Адрес не может быть пустым!", nameof( address ) );
            }
            Id = Guid.NewGuid();
            Address = address;
        }

        /// <summary>
        /// Уникальный идентификатор склада
        /// </summary>
        public Guid Id { get; }

        /// <summary>
        /// Адрес склада
        /// </summary>
        public string Address { get; }
    }
}