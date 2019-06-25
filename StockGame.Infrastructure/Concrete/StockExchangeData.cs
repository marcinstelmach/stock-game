﻿using System;
using System.Collections.Generic;
using StockGame.Infrastructure.Abstract;

namespace StockGame.Infrastructure.Concrete
{
    public class StockExchangeData :  IData
    {
        public string Name { get; set; }
        public IDictionary<DateTime, double> Rates { get; set; }
    }
}
