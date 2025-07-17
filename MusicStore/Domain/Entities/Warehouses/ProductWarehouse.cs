using MusicStore.Domain.Entities.Products;

namespace MusicStore.Domain.Entities.Warehouses
{
    /// <summary>
    /// Представляет объект, содержащий колличество определенного товара, на определенном складе
    /// </summary>
    public class ProductWarehouse
    {
        /// <summary>
        /// Создает объект, содержащий колличество определенного товара, на определенном складе, с указанными параметрами
        /// </summary>
        /// <param name="productId">Идентификатор продукта</param>
        /// <param name="warehouseId">Идентификатор склада</param>
        /// <param name="warehouseProductQuantity">Количество тована на складе</param>
        /// <exception cref="ArgumentException">Если количество товара на складе <param name="warehouseProductQuantity"> отрицательное</exception>
        /// <exception cref="ArgumentNullException">Если переданные значения параметров пустые</exception>
        public ProductWarehouse( Guid productId, Guid warehouseId, int warehouseProductQuantity )
        {
            if ( warehouseProductQuantity < 0 )
            {
                throw new ArgumentException( "Количество товара не может быть отрицательным!", nameof( warehouseProductQuantity ) );
            }
            if ( productId == Guid.Empty )
            {
                throw new ArgumentNullException( "ProductId не может быть пустым!", nameof( productId ) );
            }
            if ( warehouseId == Guid.Empty )
            {
                throw new ArgumentNullException( "WarehouseId не может быть пустым!", nameof( warehouseId ) );
            }
            ProductId = productId;
            WarehouseId = warehouseId;
            WarehouseProductQuantity = warehouseProductQuantity;
        }

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
        public int WarehouseProductQuantity { get; private set; }

        /// <summary>
        /// Увеличивает колличество товара на складе на единицу
        /// </summary>
        public void IncreaseWarehouseProductQuantity()
        {
            WarehouseProductQuantity += 1;
        }

        /// <summary>
        /// Уменьшает колличество товара на складе на единицу
        /// </summary>
        public void DecreaseWarehouseProductQuantity()
        {
            WarehouseProductQuantity -= 1;
        }
    }
}