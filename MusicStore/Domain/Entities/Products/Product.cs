namespace MusicStore.Domain.Entities.Products
{
    /// <summary>
    /// Представляет продукт в данном магазине
    /// </summary>
    public class Product
    {
        /// <summary>
        /// Создает новый продукт, используя описанные параметры
        /// </summary>
        /// <param name="name">Название продукта</param>
        /// <param name="description">Описание продукта</param>
        /// <param name="price">Цена продукта</param>
        /// <param name="priceCurrencyCode">Код валюты цены</param>
        /// <param name="imageURL">Путь к изображению продукта</param>
        /// <param name="productTypeId">Идентификатор типа продукта</param>
        /// <exception cref="ArgumentNullException">Если переданные значения параметров пустые</exception>
        /// <exception cref="ArgumentException">Если цена является недопустимой</exception>
        public Product(
            string name,
            string description,
            decimal price,
            string priceCurrencyCode,
            string imageURL,
            Guid productTypeId )
        {
            if ( name is null )
            {
                throw new ArgumentNullException( "Имя не может быть пустым!", nameof( name ) );
            }
            if ( imageURL is null )
            {
                throw new ArgumentNullException( "Путь картинки не может быть пустым!", nameof( imageURL ) );
            }
            if ( productTypeId == Guid.Empty )
            {
                throw new ArgumentNullException( "ProductTypeId не может быть пустым!", nameof( productTypeId ) );
            }
            if ( price <= 0 )
            {
                throw new ArgumentException( "Цена должна быть больше нуля!", nameof( price ) );
            }
            Id = Guid.NewGuid();
            Name = name;
            Description = description;
            Price = price;
            PriceCurrencyCode = priceCurrencyCode;
            ImageURL = imageURL;
            ProductTypeId = productTypeId;
        }

        /// <summary>
        /// Уникальный идентификатор продукта
        /// </summary>
        public Guid Id { get; }

        /// <summary>
        /// Название продукта
        /// </summary>
        public string Name { get; }

        /// <summary>
        /// Описание продукта
        /// </summary>
        public string Description { get; }

        /// <summary>
        /// Цена продукта
        /// </summary>
        public decimal Price { get; }

        /// <summary>
        /// Код валюты продукта
        /// </summary>
        public string PriceCurrencyCode { get; }

        /// <summary>
        /// Путь к изображению продукта
        /// </summary>
        public string ImageURL { get; }

        /// <summary>
        /// Идентификатор типа продукта
        /// </summary>
        public Guid ProductTypeId { get; }

        /// <summary>
        /// Содержит список тегов продукта
        /// </summary>
        public ICollection<ProductTag> Tags { get; }

        /// <summary>
        /// Добавляет тег в список тегов продукта
        /// </summary>
        /// <param name="tag">Тег продукта</param>
        public void AddTag( ProductTag tag )
        {
            if ( !Tags.Contains( tag ) )
            {
                Tags.Add( tag );
            }
        }

        /// <summary>
        /// Убирает тег из списка тегов продукта
        /// </summary>
        /// <param name="tag"></param>
        public void RemoveTag( ProductTag tag )
        {
            if ( Tags.Contains( tag ) )
            {
                Tags.Remove( tag );
            }
        }
    }
}