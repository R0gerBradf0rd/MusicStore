namespace MusicStore.Domain.Entities.Orders
{
    /// <summary>
    /// Перечисление, представляющее текущий статус заказа
    /// </summary>
    public enum OrderStatus
    {
        /// <summary>
        /// Заказ был создан
        /// </summary>
        Created = 0,

        /// <summary>
        /// Заказ находится в процессе сборки
        /// </summary>
        AssemblyProcess = 1,

        /// <summary>
        /// Заказ готов к отправке
        /// </summary>
        ReadyToShip = 2,

        /// <summary>
        /// Заказ отправлен
        /// </summary>
        Shipped = 3,

        /// <summary>
        /// Заказ доставлен
        /// </summary>
        Arrived = 4
    }
}
