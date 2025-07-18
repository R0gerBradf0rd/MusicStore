namespace MusicStore.Domain.Entities.Carts
{
    /// <summary>
    /// Представляет элемент корзины   
    /// </summary>
    public class CartItem
    {
        /// <summary>
        /// Уникальный идентификатор элемента корзины
        /// </summary>
        public Guid Id { get; }

        /// <summary>
        /// Идентификатор продукта
        /// </summary>
        public Guid ProductId { get; }

        /// <summary>
        /// Идентификатор корзины
        /// </summary>
        public Guid CartId { get; }

        /// <summary>
        /// Количество данного продукта
        /// </summary>
        public int Quantity { get; private set; }

        /// <summary>
        /// Инициализирует новый экземпляр класса <see cref="CartItem"/>
        /// </summary>
        /// <param name="productId">Идентификатор продукта</param>
        /// <param name="cartId">Идентификатор корзины</param>
        /// <param name="quantity">Количество единиц продукта. Должно быть больше нуля</param>
        /// <exception cref="ArgumentException">Если переданные значения параметров пустые</exception>
        /// <exception cref="ArgumentOutOfRangeException">Если <paramref name="quantity"/> меньше или равен нулю.</exception>
        public CartItem(
            Guid productId,
            Guid cartId,
            int quantity )
        {
            if ( productId == Guid.Empty )
            {
                throw new ArgumentException( "ProductId не может быть пустым!", nameof( productId ) );
            }
            if ( cartId == Guid.Empty )
            {
                throw new ArgumentException( "CartId не может быть пустым!", nameof( cartId ) );
            }
            if ( quantity <= 0 )
            {
                throw new ArgumentOutOfRangeException( nameof( quantity ), "Quantity должен быть больше нуля!" );
            }
            Id = Guid.NewGuid();
            ProductId = productId;
            CartId = cartId;
            Quantity = quantity;
        }

        /// <summary>
        /// Увеличивает количество продукта на одну единицу
        /// </summary>
        public void IncreaseQuantityByOne()
        {
            if ( Quantity < 999 )
            {
                Quantity += 1;
            }
        }

        /// <summary>
        /// Уменьшает количество продукта на одну единицу
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