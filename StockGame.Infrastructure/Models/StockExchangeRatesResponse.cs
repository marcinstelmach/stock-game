using System;

namespace StockGame.Infrastructure.Models
{
    public class StockExchangeRatesResponse
    {
        public DateTime date { get; set; }
        public double close { get; set; }
        public double high { get; set; }
        public double low { get; set; }
        public double open { get; set; }
        public double volume { get; set; }
        public double adjClose { get; set; }
        public double adjHigh { get; set; }
        public double adjLow { get; set; }
        public double adjOpen { get; set; }
        public double adjVolume { get; set; }
        public double divCash { get; set; }
        public double splitFactor { get; set; }
    }

}
