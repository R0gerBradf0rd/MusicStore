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
        /// <param name="userRole">Роль пользователя</param>
        /// <exception cref="ArgumentNullException">Если переданные значения параметров пустые</exception>
        public User( string name, string email, string userRole )
        {
            if ( string.IsNullOrWhiteSpace( name ) )
            {
                throw new ArgumentNullException( "Имя не может быть пустым!", nameof( name ) );
            }
            if ( string.IsNullOrWhiteSpace( email ) )
            {
                throw new ArgumentNullException( "Email не может быть пустым!", nameof( email ) );
            }
            if ( string.IsNullOrWhiteSpace( userRole ) )
            {
                throw new ArgumentNullException( "Роль не может быть пустой!", nameof( userRole ) );
            }
            if ( !UserRoles.UsersRolesList.Contains( userRole ) )
            {
                throw new ArgumentException( "Невозможно назначить несуществующую роль!", nameof( userRole ) );
            }
            Name = name;
            Email = email;
            UserRole = userRole;
            Id = Guid.NewGuid();
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