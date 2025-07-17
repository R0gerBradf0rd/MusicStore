namespace MusicStore.Domain.Entities.Products
{
    /// <summary>
    /// Представляет категорию товаров
    /// </summary>
    public class Category
    {
        /// <summary>
        /// Создает новую категорию с указанными параметрами
        /// </summary>
        /// <param name="name">Название категории</param>
        /// <exception cref="ArgumentNullException">Если переданные значения параметров пустые</exception>
        public Category( string name )
        {
            if ( name is null )
            {
                throw new ArgumentNullException( "Название не может быть пустым", nameof( name ) );
            }
            Id = Guid.NewGuid();
            Name = name;
        }
        /// <summary>
        /// Уникальный идентификатор категории
        /// </summary>
        public Guid Id { get; }

        /// <summary>
        /// Название категории
        /// </summary>
        public string Name { get; }
    }
}