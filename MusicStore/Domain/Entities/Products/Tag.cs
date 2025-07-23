namespace MusicStore.Domain.Entities.Products
{
    /// <summary>
    /// Представляет тег продукта
    /// </summary>
    public class Tag
    {
        /// <summary>
        /// Уникальный идентификатор тега
        /// </summary>
        public Guid Id { get; }

        /// <summary>
        /// Значение тега
        /// </summary>
        public string Value { get; }

        /// <summary>
        /// Создает тег продукта, с указанным параметром
        /// </summary>
        /// <param name="value">Значение тега</param>
        /// <exception cref="ArgumentNullException">Если переданное значение параметра пустое</exception>
        public Tag( string value )
        {
            if ( string.IsNullOrWhiteSpace( value ) )
            {
                throw new ArgumentNullException( "Значение не может быть пустым!", nameof( value ) );
            }
            Id = Guid.NewGuid();
            Value = value;
        }
    }
}