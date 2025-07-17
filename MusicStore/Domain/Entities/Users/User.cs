namespace MusicStore.Domain.Entities.Users
{
    /// <summary>
    /// Представляет пользователя
    /// </summary>
    public class User
    {
        /// <summary>
        /// Создает пользователя, с указанными параметрами
        /// </summary>
        /// <param name="name">Имя пользователя</param>
        /// <param name="email">Email пользователя</param>
        /// <exception cref="ArgumentNullException">Если переданные значения параметров пустые</exception>
        public User( string name, string email )
        {
            if ( name is null )
            {
                throw new ArgumentNullException( "Имя не может быть пустым!", nameof( name ) );
            }
            if ( email is null )
            {
                throw new ArgumentNullException( "Email не может быть пустым!", nameof( email ) );
            }
            Name = name;
            Email = email;
            Role = UserRole.User;
        }

        /// <summary>
        /// Уникальный идентификатор пользоваателя
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
        public UserRole Role { get; private set; }

        /// <summary>
        /// Повышает Базового пользователя до Администратора
        /// </summary>
        public void RaiseRole()
        {
            Role = UserRole.Administrator;
        }

        /// <summary>
        /// Понижает Администратора до Базового пользователя
        /// </summary>
        public void DemoteRole()
        {
            Role = UserRole.User;
        }
    }
}