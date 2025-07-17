namespace MusicStore.Domain.Entities.Orders
{
    /// <summary>
    /// 
    /// </summary>
    public class OrderItem
    {
        /// <summary>
        /// 
        /// </summary>
        public Guid Id { get; }

        public Guid ProductId { get; }

        public Guid OrderId { get; }

        public int Quantity { get; }
    }
}
// IncreaseQuantityByone
// DecreaseQuantityByOne