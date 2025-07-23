namespace MusicStore.Domain.Entities.Carts
{
    /// <summary>
    /// Представляет элемент корзины   
    /// </summary>
    public class CartItem
    {
        /// <summary>
        /// Максимальный лимит товаров в корзине
        /// </summary>
        public const int CartItemQuantityLimit = 999;

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
        /// <exception cref="ArgumentException">Если переданные значения параметров пустые</exception>
        public CartItem(
            Guid productId,
            Guid cartId )
        {
            if ( productId == Guid.Empty )
            {
                throw new ArgumentException( "ProductId не может быть пустым!", nameof( productId ) );
            }
            if ( cartId == Guid.Empty )
            {
                throw new ArgumentException( "CartId не может быть пустым!", nameof( cartId ) );
            }
            Id = Guid.NewGuid();
            ProductId = productId;
            CartId = cartId;
            Quantity = 1;
        }

        /// <summary>
        /// Увеличивает количество продукта на одну единицу
        /// </summary>
        public void IncreaseQuantityByOne()
        {
            if ( Quantity < CartItemQuantityLimit )
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