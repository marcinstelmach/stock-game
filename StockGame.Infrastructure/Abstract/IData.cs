using System;
using System.Collections.Generic;

namespace StockGame.Infrastructure.Abstract
{
    public interface IData
    {
        string Name { get; set; }

        IDictionary<DateTime, double> Rates { get; set; }
    }
}
