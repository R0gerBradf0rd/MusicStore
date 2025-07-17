namespace MusicStore.Domain.Entities.Orders
{
    public enum OrderStatus
    {
        Created = 0,
        AssemblyProccess = 1,
        ReadyToShip = 2,
        Shipped = 3,
        Arrived = 4
    }
}
