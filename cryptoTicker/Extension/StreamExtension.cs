using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace cryptoTicker.Extension
{
    public static class StreamExtension
    {
        public static string CastToString(this Stream s)
        {
            using (var streamReader = new StreamReader(s))
            {
                return streamReader.ReadToEnd();
            }
        }
    }
}
