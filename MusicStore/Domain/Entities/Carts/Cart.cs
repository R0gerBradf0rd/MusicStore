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
        /// Список товаров в корзине
        /// </summary>
        public ICollection<CartItem> CartItems { get; }

        /// <summary>
        /// Создаёт новый экземпляр корзины с указанным идентификатором пользователя
        /// </summary>
        /// <param name="userId">Идентификатор пользователя</param>
        /// <param name="cartItems">Список элементов корзины</param>
        /// <exception cref="ArgumentException">Если переданные значения параметров пустые</exception>
        public Cart( Guid userId, ICollection<CartItem> cartItems )
        {
            if ( userId == Guid.Empty )
            {
                throw new ArgumentException( "UserId не может быть пустым!", nameof( userId ) );
            }
            Id = Guid.NewGuid();
            UserId = userId;
        }

        /// <summary>
        /// Удаляет все товары из корзины
        /// </summary>
        public void Clear()
        {
            CartItems.Clear();
        }

        /// <summary>
        /// Добавляет товар в корзину
        /// </summary>
        public void AddCartItem( CartItem cartItem )
        {
            CartItems.Add( cartItem );
        }

        /// <summary>
        /// Удаляет товар из корзины
        /// </summary>
        public void RemoveCartItem( CartItem cartItem )
        {
            CartItems.Remove( cartItem );
        }
    }
}
