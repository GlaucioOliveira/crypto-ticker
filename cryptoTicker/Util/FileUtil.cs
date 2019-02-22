using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace cryptoTicker.Util
{
    public static class FileUtil
    {
        public static void SalvaArquivo(string nomeArquivo, string conteudo, string extensao = ".log")
        {
            File.AppendAllText($"{nomeArquivo}{extensao}", $"{conteudo}{Environment.NewLine}", Encoding.Default);
        }

        
        public static string LerArquivo(string nomeArquivo)
        {
            if (File.Exists("ticker.txt") == false) return "";
            return File.ReadAllText(nomeArquivo);
        }
    }
}
