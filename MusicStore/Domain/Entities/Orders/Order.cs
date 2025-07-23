namespace MusicStore.Domain.Entities.Orders
{
    /// <summary>
    /// Представляет заказ, оформленный пользователем
    /// </summary>
    public class Order
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
        /// Дата готовности к отправке
        /// </summary>
        public DateTime ReadyToShipDate { get; private set; }

        /// <summary>
        /// Дата отправки
        /// </summary>
        public DateTime ShippmentDate { get; private set; }

        /// <summary>
        /// Дата доставки
        /// </summary>
        public DateTime DeliveryDate { get; private set; }

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
        public Guid OrderNumber { get; }

        /// <summary>
        /// Адрес доставки заказа
        /// </summary>
        public string ShippingAddress { get; }

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
        /// <param name="shippingAddress">Адрес доставки</param>
        /// <param name="cartId">Идентификатор корзины</param>
        /// <exception cref="ArgumentException">Если сумма заказа недопустима</exception>
        /// <exception cref="ArgumentException">Если переданные значения параметров пустые</exception>
        public Order(
            Guid userId,
            decimal totalPrice,
            string totalPriceCurrencyCode,
            string shippingAddress,
            Guid cartId )
        {
            if ( totalPrice <= 0 )
            {
                throw new ArgumentException( "Сумма заказа должна быть больше нуля!", nameof( totalPrice ) );
            }
            if ( userId == Guid.Empty )
            {
                throw new ArgumentException( "UserId не может быть пустым!", nameof( userId ) );
            }
            if ( cartId == Guid.Empty )
            {
                throw new ArgumentException( "UserId не может быть пустым!", nameof( cartId ) );
            }
            if ( string.IsNullOrWhiteSpace( shippingAddress ) )
            {
                throw new ArgumentException( "Адрес не может быть пустым!", nameof( shippingAddress ) );
            }
            if ( !CurrencyCodeValidator.IsCurrencyCodeValid( totalPriceCurrencyCode ) )
            {
                throw new ArgumentException( "Неверный код валюты!", nameof( totalPriceCurrencyCode ) );
            }
            UserId = userId;
            TotalPrice = totalPrice;
            TotalPriceCurrencyCode = totalPriceCurrencyCode;
            ShippingAddress = shippingAddress;
            CartId = cartId;
            Status = OrderStatus.Created;
            CreationDate = DateTime.UtcNow;
            Id = Guid.NewGuid();
            OrderNumber = Guid.NewGuid();
        }

        /// <summary>
        /// Переводит заказ в состояние "Процесс сборки" и сохраняет дату начала сборки
        /// </summary>
        public void StartAssembly()
        {
            if ( Status != OrderStatus.Created )
            {
                throw new InvalidOperationException( "Не верный статуса заказа." );
            }
            Status = OrderStatus.AssemblyProcess;
            AssemblyProcessStartDate = DateTime.UtcNow;
        }
        /// <summary>
        /// Переводит заказ в состояние "Готов к отправке"
        /// </summary>
        public void EndOfAssembly()
        {
            if ( Status != OrderStatus.AssemblyProcess )
            {
                throw new InvalidOperationException( "Не верный статуса заказа." );
            }
            Status = OrderStatus.ReadyToShip;
            ReadyToShipDate = DateTime.UtcNow;
        }

        /// <summary>
        /// Переводит заказ в состояние "Отправлен"
        /// </summary>
        public void Shipping()
        {
            if ( Status != OrderStatus.ReadyToShip )
            {
                throw new InvalidOperationException( "Не верный статуса заказа." );
            }
            Status = OrderStatus.Shipped;
            ShippmentDate = DateTime.UtcNow;
        }

        /// <summary>
        /// Переводит заказ в состояние "Доставлен"
        /// </summary>
        public void Arrived()
        {
            if ( Status != OrderStatus.Shipped )
            {
                throw new InvalidOperationException( "Не верный статуса заказа." );
            }
            Status = OrderStatus.Arrived;
            DeliveryDate = DateTime.UtcNow;
        }
    }
}