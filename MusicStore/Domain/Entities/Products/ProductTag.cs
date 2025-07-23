namespace MusicStore.Domain.Entities.Products
{
    /// <summary>
    /// Представляет связь между тегом и продуктом
    /// </summary>
    public class ProductTag
    {
        /// <summary>
        /// Идентификатор тега продукта
        /// </summary>
        public Guid TagId { get; }

        /// <summary>
        /// Идентификатор продукта
        /// </summary>
        public Guid ProductId { get; }

        /// <summary>
        /// Создает объект, содержащий теги, принадлежащие продукту, с указанными параметрами
        /// </summary>
        /// <param name="tagId">Идентификатор тега</param>
        /// <param name="productId">Идентификатор продукта</param>
        /// <exception cref="ArgumentException">Если переданные значения параметров пустые</exception>
        public ProductTag( Guid tagId, Guid productId )
        {
            if ( productId == Guid.Empty )
            {
                throw new ArgumentException( "ProductId не может быть пустым!", nameof( productId ) );
            }
            if ( tagId == Guid.Empty )
            {
                throw new ArgumentException( "TagId не может быть пустым!", nameof( tagId ) );
            }
            TagId = tagId;
            ProductId = productId;
        }
    }
}
