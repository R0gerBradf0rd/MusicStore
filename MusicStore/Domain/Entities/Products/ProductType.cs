namespace MusicStore.Domain.Entities.Products
{
    /// <summary>
    /// Представляет собой тип продукта, относящийся к определенной категории
    /// </summary>
    public class ProductType
    {
        /// <summary>
        /// Создает тип продукта, относящийся к определенной категории, с указанными параметрами
        /// </summary>
        /// <param name="name">Название типа</param>
        /// <param name="catergoryId">Идентификатор категории</param>
        /// <exception cref="ArgumentNullException">Если переданные значения параметров пустые</exception>
        public ProductType( string name, Guid catergoryId )
        {
            if ( catergoryId == Guid.Empty )
            {
                throw new ArgumentNullException( "CategoryId не может быть пустым!", nameof( catergoryId ) );
            }
            if ( name is null )
            {
                throw new ArgumentNullException( "Название не может быть пустым!", nameof( name ) );
            }
            Id = Guid.NewGuid();
            Name = name;
            CatergoryId = catergoryId;
        }

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
    }
}