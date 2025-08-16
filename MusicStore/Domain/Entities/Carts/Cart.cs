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
        /// Полная стоимость товаров в корзине
        /// </summary>
        public decimal TotalPrice { get; private set; }

        /// <summary>
        /// Создаёт новый экземпляр корзины с указанным идентификатором пользователя
        /// </summary>
        /// <param name="userId">Идентификатор пользователя</param>
        /// <exception cref="ArgumentException">Если переданные значения параметров пустые</exception>
        public Cart( Guid userId )
        {
            if ( userId == Guid.Empty )
            {
                throw new ArgumentException( "UserId не может быть пустым!", nameof( userId ) );
            }
            Id = Guid.NewGuid();
            UserId = userId;
        }

        /// <summary>
        /// Удаляет все товары из корзины, обнуляет счетчик товаров
        /// </summary>
        public void Clear()
        {
            CartItems.Clear();
        }

        /// <summary>
        /// Добавляет товар в корзину, увеличивает счетчик товаров на 1
        /// </summary>
        public void AddCartItem( CartItem cartItem )
        {
            if ( !CartItems.Contains( cartItem ) )
            {
                CartItems.Add( cartItem );
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
            }
        }

        /// <summary>
        /// Вычисляет общую стоимость товаров в корзине
        /// </summary>
        public void UppdateTotalPrice()
        {
            List<CartItem> cartItems = CartItems.ToList();
            for ( int i = 0; i < cartItems.Count; i++ )
            {
                if ( cartItems[ i ].IsSelected == CartItemSelectionStatus.Selected )
                {
                    TotalPrice += cartItems[ i ].TotalPrice;
                }
            }
        }
    }
}
