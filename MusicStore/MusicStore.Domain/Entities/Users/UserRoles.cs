namespace MusicStore.Domain.Entities.Users
{
    /// <summary>
    /// Статический класс, представляющий роли пользователя
    /// </summary>
    public static class UserRoles
    {
        /// <summary>
        /// Роль покупателя
        /// </summary>
        public const string Buyer = "buyer";

        /// <summary>
        /// Роль администратор
        /// </summary>
        public const string Administrator = "administrator";

        /// <summary>
        /// Список всех ролей, доступных пользователю
        /// </summary>
        public static readonly List<string> UsersRolesList = new List<string>()
        {
            Buyer,
            Administrator
        };
    }
}
