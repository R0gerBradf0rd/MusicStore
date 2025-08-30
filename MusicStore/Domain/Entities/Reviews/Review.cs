namespace MusicStore.Domain.Entities.Reviews
{
    /// <summary>
    /// Представляет отзыв пользователя, для определенного товара
    /// </summary>
    public class Review
    {
        /// <summary>
        /// Уникальный идентификатор отзыва
        /// </summary>
        public Guid Id { get; }

        /// <summary>
        /// Идентификатор продукта
        /// </summary>
        public Guid ProductId { get; }

        /// <summary>
        /// Идентификатор пользователя
        /// </summary>
        public Guid UserId { get; }

        /// <summary>
        /// Оценка пользователя товару, от 1 до 5
        /// </summary>
        public int Rating { get; }

        /// <summary>
        /// Комментарий к отзыву
        /// </summary>
        public string Comment { get; }

        /// <summary>
        /// Создает отзыв пользователя, для определенного товара, с указанными параметрами
        /// </summary>
        /// <param name="productId">Идентификатор продукта</param>
        /// <param name="userId">Идентификатор пользователя</param>
        /// <param name="rating">Оценка пользователя товару</param>
        /// <param name="comment">Комментарий к отзыву</param>
        /// <exception cref="ArgumentException">Если переданные значения параметров пустые</exception>
        /// <exception cref="ArgumentOutOfRangeException">Если рейтинг меньше 1 или больше 5</exception>
        public Review(
            Guid productId,
            Guid userId,
            int rating,
            string comment )
        {
            if ( productId == Guid.Empty )
            {
                throw new ArgumentException( "ProductId не может быть пустым!", nameof( productId ) );
            }
            if ( userId == Guid.Empty )
            {
                throw new ArgumentException( "UserId не может быть пустым!", nameof( userId ) );
            }
            if ( rating < 0 || rating > 5 )
            {
                throw new ArgumentOutOfRangeException( "Рейтинг не может быть больше 5 и меньше 0!", nameof( rating ) );
            }
            Id = Guid.NewGuid();
            ProductId = productId;
            UserId = userId;
            Rating = rating;
            Comment = comment;
        }

        /// <summary>
        /// Конструктор для EntityFramework
        /// </summary>
        private Review()
        { }
    }
}