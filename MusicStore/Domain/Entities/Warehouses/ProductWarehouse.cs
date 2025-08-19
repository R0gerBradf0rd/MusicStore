namespace MusicStore.Domain.Entities.Warehouses
{
    /// <summary>
    /// Представляет объект, содержащий количество определенного товара, на определенном складе
    /// </summary>
    public class ProductWarehouse
    {
        /// <summary>
        /// Идентификатор продукта
        /// </summary>
        public Guid ProductId { get; }

        /// <summary>
        /// Идентификатор склада
        /// </summary>
        public Guid WarehouseId { get; }

        /// <summary>
        /// Колличество товара на складе
        /// </summary>
        public int Quantity { get; private set; }

        /// <summary>
        /// Создает объект, содержащий колличество определенного товара, на определенном складе, с указанными параметрами
        /// </summary>
        /// <param name="productId">Идентификатор продукта</param>
        /// <param name="warehouseId">Идентификатор склада</param>
        /// <param name="quantity">Количество товара на складе</param>
        /// <exception cref="ArgumentException">Если количество товара на складе warehouseProductQuantity отрицательное</exception>
        /// <exception cref="ArgumentException">Если переданные значения параметров пустые</exception>
        public ProductWarehouse( Guid productId, Guid warehouseId, int quantity )
        {
            if ( quantity < 0 )
            {
                throw new ArgumentException( "Количество товара не может быть отрицательным!", nameof( quantity ) );
            }
            if ( productId == Guid.Empty )
            {
                throw new ArgumentException( "ProductId не может быть пустым!", nameof( productId ) );
            }
            if ( warehouseId == Guid.Empty )
            {
                throw new ArgumentException( "WarehouseId не может быть пустым!", nameof( warehouseId ) );
            }
            ProductId = productId;
            WarehouseId = warehouseId;
            Quantity = quantity;
        }

        /// <summary>
        /// Увеличивает колличество товара на складе на заданное число
        /// </summary>
        public void AddProductToWarehouse( int count )
        {
            Quantity += count;
        }

        /// <summary>
        /// Уменьшает колличество товара на складе на заданное число
        /// </summary>
        public void TakeProductFromWarehouse( int count )
        {
            if ( Quantity - count < 0 )
            {
                throw new InvalidOperationException( "Невозможно взять данное количество товара со склада!" );
            }
            Quantity -= count;
        }
    }
}