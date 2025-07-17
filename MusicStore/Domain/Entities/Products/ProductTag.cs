namespace MusicStore.Domain.Entities.Products
{
    /// <summary>
    /// Представляет объект, содержащий теги, принадлежащие продукту
    /// </summary>
    public class ProductTag
    {
        /// <summary>
        /// Создает объект, содержащий теги, принадлежащие продукту, с указанными параметрами
        /// </summary>
        /// <param name="tagId">Идентификатор тега</param>
        /// <param name="productId">Идентификатор продукта</param>
        /// <exception cref="ArgumentNullException">Если переданные значения параметров пустые</exception>
        public ProductTag( Guid tagId, Guid productId )
        {
            if ( productId == Guid.Empty )
            {
                throw new ArgumentNullException( "ProductId не может быть пустым!", nameof( productId ) );
            }
            if ( tagId == Guid.Empty )
            {
                throw new ArgumentNullException( "TagId не может быть пустым!", nameof( tagId ) );
            }
            TagId = tagId;
            ProductId = productId;
        }

        /// <summary>
        /// Идентификатор тега продукта
        /// </summary>
        public Guid TagId { get; }

        /// <summary>
        /// Идентификатор продукта
        /// </summary>
        public Guid ProductId { get; }
    }
}
