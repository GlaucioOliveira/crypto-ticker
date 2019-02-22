using System;
using System.Collections.Generic;
using System.Text;

namespace cryptoTicker.Model
{
    public class Ticker
    {
        public decimal high { get; set; }
        public decimal low { get; set; }
        public decimal last { get; set; }
        public decimal buy { get; set; }
        public decimal sell { get; set; }
        public DateTime date { get; set; }
        public decimal trades_quantity { get; set; }
        public decimal volume { get; set; }
    }
}
