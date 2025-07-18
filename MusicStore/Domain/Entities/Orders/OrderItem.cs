namespace MusicStore.Domain.Entities.Orders
{
    /// <summary>
    /// Представляет элемент заказа
    /// </summary>
    public class OrderItem
    {
        /// <summary>
        /// Уникальный идентификатор элемента заказа
        /// </summary>
        public Guid Id { get; }

        /// <summary>
        /// Идентификатор продукта в заказе
        /// </summary>
        public Guid ProductId { get; }

        /// <summary>
        /// Идентификатор заказа, к которому относится элемент
        /// </summary>
        public Guid OrderId { get; }

        /// <summary>
        /// Количество продукта в элементе заказа
        /// </summary>
        public int Quantity { get; private set; }

        /// <summary>
        /// Создает новый элемент заказа с указанными идентификаторами
        /// </summary>
        /// <param name="productId">Идентификатор продукта</param>
        /// <param name="orderId">Идентификатор заказа</param>
        /// <param name="quantity">Количество продукта</param>
        /// <exception cref="ArgumentException">Если переданные значения параметров пустые</exception>
        public OrderItem( Guid productId, Guid orderId, int quantity )
        {
            if ( productId == Guid.Empty )
            {
                throw new ArgumentException( "ProductId не может быть пустым!", nameof( productId ) );
            }
            if ( orderId == Guid.Empty )
            {
                throw new ArgumentException( "OrderId не может быть пустым!", nameof( orderId ) );
            }
            if ( quantity <= 0 )
            {
                throw new ArgumentException( "Количество должно быть больше нуля!", nameof( quantity ) );
            }
            Id = Guid.NewGuid();
            ProductId = productId;
            OrderId = orderId;
            Quantity = quantity;
        }

        /// <summary>
        /// Увеличивает количество продукта в элементе на единицу
        /// </summary>
        public void IncreaseQuantityByOne()
        {
            if ( Quantity < 999 )
            {
                Quantity += 1;
            }
        }

        /// <summary>
        /// Уменьшает количество продукта в элементе на единицу
        /// </summary>
        public void DecreaseQuantityByOne()
        {
            if ( Quantity > 1 )
            {
                Quantity -= 1;
            }
        }
    }
}