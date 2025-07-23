namespace MusicStore.Domain.Entities.Products
{
    /// <summary>
    /// Представляет собой тип продукта, относящийся к определенной категории
    /// </summary>
    public class ProductType
    {
        /// <summary>
        /// Уникальный идентификатор типа продукта
        /// </summary>
        public Guid Id { get; }

        /// <summary>
        /// Название типа продукта
        /// </summary>
        public string Name { get; }

        /// <summary>
        /// Идентификатор категории
        /// </summary>
        public Guid CatergoryId { get; }

        /// <summary>
        /// Создает тип продукта, относящийся к определенной категории, с указанными параметрами
        /// </summary>
        /// <param name="name">Название типа</param>
        /// <param name="categoryId">Идентификатор категории</param>
        /// <exception cref="ArgumentNullException">Если переданные значения параметров пустые</exception>
        /// <exception cref="ArgumentException">Если переданные значения параметров пустые</exception>
        public ProductType( string name, Guid categoryId )
        {
            if ( categoryId == Guid.Empty )
            {
                throw new ArgumentException( "CategoryId не может быть пустым!", nameof( categoryId ) );
            }
            if ( string.IsNullOrWhiteSpace( name ) )
            {
                throw new ArgumentNullException( "Название не может быть пустым!", nameof( name ) );
            }
            Id = Guid.NewGuid();
            Name = name;
            CatergoryId = categoryId;
        }
    }
}