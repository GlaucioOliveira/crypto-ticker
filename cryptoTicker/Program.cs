using cryptoTicker.Extension;
using cryptoTicker.Model;
using cryptoTicker.Util;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using MongoDB;
using cryptoTicker.DBConnection;

namespace cryptoTicker
{
    class Program
    {
        private static HttpClient client;
        private static Dictionary<String, String> EndpointsList;

        static void Main(string[] args)
        {
            client = new HttpClient(new HttpClientHandler
            {
                UseCookies = false,
                UseDefaultCredentials = true,
                AllowAutoRedirect = true
            });

            EndpointsList = new Dictionary<String, String>()
            {
              { "BTC", "https://api.bitcointrade.com.br/v2/public/BRLBTC/ticker" },
              { "XRP", "https://api.bitcointrade.com.br/v2/public/BRLXRP/ticker" },
              { "ETH", "https://api.bitcointrade.com.br/v2/public/BRLETH/ticker" },
            };

            foreach (var endpoint in EndpointsList)
            {

                ProcessEndPoint(endpoint.Value).Wait();
                string endpointHttpResult = ProcessEndPoint(endpoint.Value).Result;

                if (!String.IsNullOrWhiteSpace(endpointHttpResult))
                {
                    var cryptoTickerResult = JsonConvert.DeserializeObject<CryptoTicker>(endpointHttpResult);
                    cryptoTickerResult.cryptoName = endpoint.Key;
                    var tickerDataResult = cryptoTickerResult.data;

                    //salva no mongoDB; (future...)
                    //db.CryptoTicker.InsertOne(cryptoTickerResult);
                    FileUtil.SalvaArquivo(endpoint.Key, endpointHttpResult);
                }
            }
        }

        private static async Task<string> ProcessEndPoint(string CurrentGetEndPoint)
        {
            client.DefaultRequestHeaders.Add("User-Agent", ".NET Crypto Ticker");

            var stringTask = client.GetStringAsync(CurrentGetEndPoint);
            return await stringTask;
        }
    }
}
