namespace MusicStore.Domain.Entities.Carts
{
    /// <summary>
    /// Перечисление, представляющее статус элемента корзины для заказа
    /// </summary>
    public enum CartItemSelectionStatus
    {
        /// <summary>
        /// Выбран для заказа
        /// </summary>
        Selected = 0,

        /// <summary>
        /// Не выбран для заказа
        /// </summary>
        Unselected = 1
    }
}
