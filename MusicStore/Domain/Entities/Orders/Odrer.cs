namespace MusicStore.Domain.Entities.Orders
{
    /// <summary>
    /// Представляет заказ, оформленный пользователем
    /// </summary>
    public class Odrer
    {
        /// <summary>
        /// Уникальный идентификатор заказа
        /// </summary>
        public Guid Id { get; }

        /// <summary>
        /// Идентификатор пользователя, оформившего заказ
        /// </summary>
        public Guid UserId { get; }

        /// <summary>
        /// Текущий статус заказа
        /// </summary>
        public OrderStatus Status { get; private set; }

        /// <summary>
        /// Дата создания заказа
        /// </summary>
        public DateTime CreationDate { get; }

        /// <summary>
        /// Дата начала сборки заказа
        /// </summary>
        public DateTime AssemblyProcessStartDate { get; private set; }

        /// <summary>
        /// Общая сумма заказа
        /// </summary>
        public decimal TotalPrice { get; }

        /// <summary>
        /// Код валюты, в которой указан итог заказа
        /// </summary>
        public string TotalPriceCurrencyCode { get; }

        /// <summary>
        /// Уникальный номер заказа
        /// </summary>
        public string OrderNumber { get; } // создать сервис

        /// <summary>
        /// Адрес доставки заказа
        /// </summary>
        public string ShippingAssress { get; }

        /// <summary>
        /// Идентификатор корзины, из которой был создан заказ
        /// </summary>
        public Guid CartId { get; }

        /// <summary>
        /// Создаёт новый заказ с указанными параметрами
        /// </summary>
        /// <param name="userId">Идентификатор пользователя</param>
        /// <param name="totalPrice">Итоговая сумма заказа</param>
        /// <param name="totalPriceCurrencyCode">Код валюты заказа</param>
        /// <param name="shippingAssress">Адрес доставки</param>
        /// <param name="cartId">Идентификатор корзины</param>
        /// <exception cref="ArgumentException">Если сумма заказа недопустима</exception>
        /// <exception cref="ArgumentNullException">Если переданные значения параметров пустые</exception>
        public Odrer( Guid userId, decimal totalPrice, string totalPriceCurrencyCode, string shippingAssress, Guid cartId )
        {
            if ( totalPrice <= 0 )
            {
                throw new ArgumentException( "Сумма заказа должна быть больше нуля!", nameof( totalPrice ) );
            }
            if ( userId == Guid.Empty )
            {
                throw new ArgumentNullException( "UserId не может быть пустым!", nameof( userId ) );
            }
            if ( cartId == Guid.Empty )
            {
                throw new ArgumentNullException( "UserId не может быть пустым!", nameof( cartId ) );
            }
            if ( shippingAssress is null )
            {
                throw new ArgumentNullException( "Адрес не может быть пустым!", nameof( shippingAssress ) );
            }
            UserId = userId;
            TotalPrice = totalPrice;
            TotalPriceCurrencyCode = totalPriceCurrencyCode;
            ShippingAssress = shippingAssress;
            CartId = cartId;
            Status = OrderStatus.Created;
            CreationDate = DateTime.UtcNow;
            Id = Guid.NewGuid();
        }


        /// <summary>
        /// Переводит заказ в состояние "Процесс сборки" и сохраняет дату начала сборки
        /// </summary>
        public void StartAssembly()
        {
            Status = OrderStatus.AssemblyProccess;
            AssemblyProcessStartDate = DateTime.UtcNow;
        }

        /// <summary>
        /// Переводит заказ в состояние "Готов к отправке"
        /// </summary>
        public void EndOfAssembly()
        {
            Status = OrderStatus.ReadyToShip;
        }

        /// <summary>
        /// Переводит заказ в состояние "Отправлен"
        /// </summary>
        public void Shipping()
        {
            Status = OrderStatus.Shipped;
        }

        /// <summary>
        /// Переводит заказ в состояние "Доставлен"
        /// </summary>
        public void Arrived()
        {
            Status = OrderStatus.Arrived;
        }
    }
}