using System;
using System.Collections.Generic;
using System.Text;
using cryptoTicker.Model;
using MongoDB.Driver;

namespace cryptoTicker.DBConnection
{
    public class MongoDbContext
    {
        public static string ConnectionString { get; set; }
        public static string DatabaseName { get; set; }
        public static bool IsSSL { get; set; }
        private IMongoDatabase _database { get; }

        public MongoDbContext(string connectionString = "", string databaseName = "", bool isSSL = true)
        {
            if(connectionString != "") ConnectionString = connectionString;
            if (databaseName != "") DatabaseName = databaseName;
            IsSSL = isSSL;

            try
            {                
                MongoClientSettings settings = MongoClientSettings.FromUrl(new MongoUrl(ConnectionString));

                if (IsSSL)
                {
                    settings.SslSettings = new SslSettings { EnabledSslProtocols = System.Security.Authentication.SslProtocols.Tls12 };
                }
                var mongoClient = new MongoClient(settings);
                _database = mongoClient.GetDatabase(DatabaseName);
            }
            catch (Exception ex)
            {
                throw new Exception("Não foi possível se conectar com o servidor.", ex);
            }
        }

        public IMongoCollection<CryptoTicker> CryptoTicker
        {
            get
            {
                return _database.GetCollection<CryptoTicker>("CryptoTicker");
            }
        }
    }
}
