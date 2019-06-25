using System;

namespace StockGame.Web
{
    public static class Extensions
    {
        public static string GetName<T>(this Enum obj) where T : Enum
        {
            return Enum.GetName(typeof(T), obj);
        }
    }
}
