using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace StockGame.Web.Models
{
    public class SelectorDataViewModel
    {
        public DataType DataType { get; set; }

        public DateTime From { get; set; }

        public DateTime To { get; set; }

        public List<SelectListItem> DataTypes { get; } = new List<SelectListItem>
        {
            new SelectListItem{ Value = ((int)DataType.ExchangeRates).ToString(), Text = DataType.ExchangeRates.GetName<DataType>()},
            new SelectListItem{ Value = ((int)DataType.GoldRates).ToString(), Text = DataType.GoldRates.GetName<DataType>()},
            new SelectListItem{ Value = ((int)DataType.StockExchange).ToString(), Text = DataType.StockExchange.GetName<DataType>()}
        };
    }
}
