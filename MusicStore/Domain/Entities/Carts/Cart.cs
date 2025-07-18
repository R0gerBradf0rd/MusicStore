namespace MusicStore.Domain.Entities.Carts
{
    /// <summary>
    /// Представляет корзину пользователя, содержащую список выбранных товаров
    /// </summary>
    public class Cart
    {
        /// <summary>
        /// Уникальный идентификатор корзины
        /// </summary>
        public Guid Id { get; }

        /// <summary>
        /// Идентификатор пользователя, которому принадлежит корзина
        /// </summary>
        public Guid UserId { get; }

        /// <summary>
        /// Счетчик элементов корзины
        /// </summary>
        public int CartItemsQuantity { get; private set; }

        /// <summary>
        /// Список товаров в корзине
        /// </summary>
        public ICollection<CartItem> CartItems { get; } = new List<CartItem>();

        /// <summary>
        /// Создаёт новый экземпляр корзины с указанным идентификатором пользователя
        /// </summary>
        /// <param name="userId">Идентификатор пользователя</param>
        /// <param name="cartItems">Список элементов корзины</param>
        /// <exception cref="ArgumentException">Если переданные значения параметров пустые</exception>
        public Cart( Guid userId )
        {
            if ( userId == Guid.Empty )
            {
                throw new ArgumentException( "UserId не может быть пустым!", nameof( userId ) );
            }
            Id = Guid.NewGuid();
            UserId = userId;
            CartItemsQuantity = 0;
        }

        /// <summary>
        /// Удаляет все товары из корзины, обнуляет счетчик товаров
        /// </summary>
        public void Clear()
        {
            CartItems.Clear();
            CartItemsQuantity = 0;
        }

        /// <summary>
        /// Добавляет товар в корзину, увеличивает счетчик товаров на 1
        /// </summary>
        public void AddCartItem( CartItem cartItem )
        {
            if ( !CartItems.Contains( cartItem ) )
            {
                CartItems.Add( cartItem );
                CartItemsQuantity += 1;
            }
        }

        /// <summary>
        /// Удаляет товар из корзины, уменьшает счетчик товаров на 1
        /// </summary>
        public void RemoveCartItem( CartItem cartItem )
        {
            if ( CartItems.Contains( cartItem ) )
            {
                CartItems.Remove( cartItem );
                CartItemsQuantity -= 1;
            }
        }
    }
}
