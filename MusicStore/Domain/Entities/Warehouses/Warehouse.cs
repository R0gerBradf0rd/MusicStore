namespace MusicStore.Domain.Entities.Warehouses
{
    /// <summary>
    /// Представляет склад, на котором содержатся товары
    /// </summary>
    public class Warehouse
    {
        /// <summary>
        /// Уникальный идентификатор склада
        /// </summary>
        public Guid Id { get; }

        /// <summary>
        /// Адрес склада
        /// </summary>
        public string Address { get; }

        /// <summary>
        /// Список товаров на складе
        /// </summary>
        public ICollection<ProductWarehouse> ProductWarehouseItems { get; }

        /// <summary>
        /// Создает склад, на котором содержатся товары, с указанным идентификатором
        /// </summary>
        /// <param name="address">Адрес склада</param>
        /// <exception cref="ArgumentNullException">Если переданное значение параметра пустое</exception>
        public Warehouse( string address )
        {
            if ( string.IsNullOrWhiteSpace( address ) )
            {
                throw new ArgumentNullException( "Адрес не может быть пустым!", nameof( address ) );
            }
            Id = Guid.NewGuid();
            Address = address;
        }

        /// <summary>
        /// Добавляет товар на склад
        /// </summary>
        /// <param name="productWarehouse">Объект, содержащий количество определенного товара, на определенном складе</param>
        public void AddProductToWarehouse( ProductWarehouse productWarehouse )
        {
            ProductWarehouseItems.Add( productWarehouse );
        }
    }
}