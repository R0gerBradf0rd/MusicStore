namespace MusicStore.Domain.Entities
{
    /// <summary>
    /// Статический класс, который проверяет правильность кода валюты
    /// </summary>
    public static class CurrencyCodeValidator
    {
        /// <summary>
        /// Список всех кодов валют
        /// </summary>
        private readonly static IReadOnlyList<string> currencyCodes = new List<string>() { "RUB" };

        /// <summary>
        /// Метод типа bool, который принимает код валюты, сверяет со списком кодов валют 
        /// и возвращает true или false
        /// </summary>
        /// <param name="currencyCode">Принимаемыей код валюты</param>
        /// <returns>true, если код содержится в списке кодов валют</returns>
        /// <returs>false, если код не содержится в списке кодов валют</returs>
        public static bool IsCurrencyCodeValid( string currencyCode )
        {
            if ( currencyCodes.Contains( currencyCode ) )
            {
                return true;
            }
            return false;
        }
    }
}
