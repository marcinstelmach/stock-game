using System;
using StockGame.Infrastructure.Concrete;
using StockGame.Infrastructure.Models;

namespace StockGame.Infrastructure
{
    public static class Extensions
    {
        public static string GetName<T>(this Enum obj) where T : Enum
        {
            return Enum.GetName(typeof(T), obj);
        }

        public static DateTime ToDateTime(this string text)
        {
            if (!DateTime.TryParse(text, out var date))
            {
                throw new Exception($"Cannot parse string to date: {text}.");
            }

            return date;
        }

        public static Type GetReaderType(this DataType dataType)
        {
            if (dataType == DataType.ExchangeRates)
                return typeof(ExchangeRatesDataReader);

            if (dataType == DataType.GoldRates)
                return typeof(GoldRatesDataReader);

            if (dataType == DataType.StockExchange)
                return typeof(StockExchangeDataReader);

            throw new NotImplementedException();
        }
    }
}
