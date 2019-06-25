using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Extensions.DependencyInjection;
using StockGame.Infrastructure.Abstract;
using StockGame.Infrastructure.Models;

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

        public IDataReader CreateDataReader(DataType dataType)
        {
            return dataReaders.First(s => s.GetType() == dataType.GetReaderType());
        }
    }
}
