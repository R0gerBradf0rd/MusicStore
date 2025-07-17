namespace MusicStore.Domain.Entities.Carts
{
    /// <summary>
    /// Представляет корзину пользователя, содержащую список выбранных товаров
    /// </summary>
    public class Cart
    {
        /// <summary>
        /// Создаёт новый экземпляр корзины с указанным идентификатором пользователя
        /// </summary>
        /// <param name="id">Идентификатор корзины</param>
        /// <param name="userId">Идентификатор пользователя</param>
        /// <exception cref="ArgumentNullException">Если переданные значения параметров пустые</exception>
        public Cart( Guid id, Guid userId )
        {
            if ( userId == Guid.Empty )
            {
                throw new ArgumentNullException( "UserId не может быть пустым!", nameof( userId ) );
            }
            Id = Guid.NewGuid();
            UserId = userId;
        }

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
        public ICollection<CartItem> Items { get; }

        /// <summary>
        /// Удаляет все товары из корзины
        /// </summary>
        public void Clear()
        {
            Items.Clear();
        }

        /// <summary>
        /// Добавляет товар в корзину
        /// </summary>
        public void AddCartItem( CartItem cartItem )
        {
            Items.Add( cartItem );
        }

        /// <summary>
        /// Удаляет товар из корзины
        /// </summary>
        public void RemoveCartItem( CartItem cartItem )
        {
            Items.Remove( cartItem );
        }
    }
}
