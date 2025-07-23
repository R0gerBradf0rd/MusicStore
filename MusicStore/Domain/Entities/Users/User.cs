namespace MusicStore.Domain.Entities.Users
{
    /// <summary>
    /// Представляет пользователя
    /// </summary>
    public class User
    {
        /// <summary>
        /// Уникальный идентификатор пользователя
        /// </summary>
        public Guid Id { get; }

        /// <summary>
        /// Имя пользователя
        /// </summary>
        public string Name { get; }

        /// <summary>
        /// Email пользователя
        /// </summary>
        public string Email { get; }

        /// <summary>
        /// Роль пользователя
        /// </summary>
        public string UserRole { get; private set; }

        /// <summary>
        /// Создает пользователя, с указанными параметрами
        /// </summary>
        /// <param name="name">Имя пользователя</param>
        /// <param name="email">Email пользователя</param>
        /// <exception cref="ArgumentNullException">Если переданные значения параметров пустые</exception>
        public User( string name, string email )
        {
            if ( string.IsNullOrWhiteSpace( name ) )
            {
                throw new ArgumentNullException( "Имя не может быть пустым!", nameof( name ) );
            }
            if ( string.IsNullOrWhiteSpace( email ) )
            {
                throw new ArgumentNullException( "Email не может быть пустым!", nameof( email ) );
            }
            Name = name;
            Email = email;
            UserRole = UserRoles.Buyer;
        }

        /// <summary>
        /// Присваивает пользователю переданную роль
        /// </summary>
        public void AssignRole( string role )
        {
            if ( !UserRoles.UsersRolesList.Contains( role ) )
            {
                throw new InvalidOperationException( "Невозможно назначить несуществующую роль!" );
            }
            UserRole = role;
        }
    }
}