namespace MusicStore.Domain.Entities.Users
{
    /// <summary>
    /// Перечисление, представляющее роль пользователя
    /// </summary>
    public enum UserRole
    {
        /// <summary>
        /// Базовый пользователь
        /// </summary>
        User = 0,

        /// <summary>
        /// Администратор
        /// </summary>
        Administrator = 1
    }
}
