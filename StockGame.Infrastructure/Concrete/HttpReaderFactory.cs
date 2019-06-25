using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Extensions.DependencyInjection;
using StockGame.Infrastructure.Abstract;

namespace StockGame.Infrastructure.Concrete
{
    internal class HttpReaderFactory : IDataReaderFactory
    {
        private static IEnumerable<IDataReader> dataReaders;
        private static HttpReaderFactory instance;

        public static IDataReaderFactory Instance(IServiceProvider serviceProvider)
        {
            if (instance == null)
            {
                instance = new HttpReaderFactory();
                dataReaders = serviceProvider.GetServices<IDataReader>();
            }

            return instance;
        }

        private HttpReaderFactory()
        {
        }

        public IDataReader CreateDataReader<T>() where T : IDataReader
        {
            return dataReaders.First(s => s.GetType() == typeof(T));
        }
    }
}
