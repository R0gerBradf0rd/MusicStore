namespace MusicStore.Domain.Entities.Users
{
    /// <summary>
    /// Статический класс, представляющий роли пользователя
    /// </summary>
    public static class UserRole
    {
        /// <summary>
        /// Роль покупателя
        /// </summary>
        public static readonly string Buyer = "user";

        /// <summary>
        /// Роль администратор
        /// </summary>
        public static readonly string Administrator = "administrator";

        /// <summary>
        /// Список всех ролей, доступных пользователю
        /// </summary>
        public static readonly List<string> UsersRoles = new List<string>()
        {
            Buyer,
            Administrator };
    }
}
