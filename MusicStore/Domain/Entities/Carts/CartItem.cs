using MusicStore.Domain.Entities.Products;

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
        /// Ссылка на объект продукта
        /// </summary>
        public Product Product { get; }

        /// <summary>
        /// Идентификатор корзины
        /// </summary>
        public Guid CartId { get; }

        /// <summary>
        /// Цена элемента корзины
        /// </summary>
        public decimal TotalPrice { get; private set; }

        /// <summary>
        /// Количество данного продукта
        /// </summary>
        public int Quantity { get; private set; }

        /// <summary>
        /// Отображает статус элемента, выбран ли он для заказа
        /// </summary>
        public CartItemSelectionStatus IsSelected { get; private set; }

        /// <summary>
        /// Инициализирует новый экземпляр класса <see cref="CartItem"/>
        /// </summary>
        /// <param name="productId">Идентификатор продукта</param>
        /// <param name="cartId">Идентификатор корзины</param>
        /// <param name="product">Объект продукта</param>
        /// <exception cref="ArgumentException">Если переданные значения параметров пустые</exception>
        public CartItem(
            Guid productId,
            Guid cartId,
            Product product )
        {
            if ( productId == Guid.Empty )
            {
                throw new ArgumentException( "ProductId не может быть пустым!", nameof( productId ) );
            }
            if ( cartId == Guid.Empty )
            {
                throw new ArgumentException( "CartId не может быть пустым!", nameof( cartId ) );
            }
            if ( ProductId != product.Id )
            {
                throw new ArgumentException( "Не верный Id или объект продукта!" );
            }
            Id = Guid.NewGuid();
            ProductId = productId;
            CartId = cartId;
            Product = product;
            Quantity = 1;
            TotalPrice = Quantity * product.Price;
            IsSelected = CartItemSelectionStatus.Selected;
        }

        /// <summary>
        /// Устанавливает количество продукта в элементе корзины
        /// </summary>
        public void SetQuantity( int quantity )
        {
            if ( quantity < 1 )
            {
                throw new InvalidOperationException( "Количество товара должно быть больше нуля!" );
            }
            if ( quantity > CartItemQuantityLimit )
            {
                throw new InvalidOperationException( $"Количество товара не должно быть больше {CartItemQuantityLimit}!" );
            }
            Quantity = quantity;
            TotalPrice = Quantity * Product.Price;
        }

        /// <summary>
        /// Меняет статус на установленный
        /// </summary>
        public void SetSelectionStatus( CartItemSelectionStatus selectionStatus )
        {
            IsSelected = selectionStatus;
        }
    }
}