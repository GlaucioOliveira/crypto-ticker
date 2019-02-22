using System;
using System.Collections.Generic;
using System.Text;

namespace cryptoTicker.Model
{
    public class CryptoTicker
    {
        public string cryptoName { get; set; }
        public string code { get; set; }
        public string message { get; set; }
        public Ticker data { get; set; }
    }
}
