using System;
using System.Net;
using System.IO;

namespace Omnia2AI
{
    class Program
    {
        // Proxy sunucunun adresi (Evde bilgisayarını açınca IP adresini buraya yazacaksın)
        static string proxyUrl = "http://BILGISAYAR_IP_ADRESI:5000/ai?q=";

        public static string AskAI(string prompt)
        {
            try
            {
                string url = proxyUrl + Uri.EscapeDataString(prompt);
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
                request.Method = "GET";

                using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
                using (StreamReader reader = new StreamReader(response.GetResponseStream()))
                {
                    return reader.ReadToEnd();
                }
            }
            catch (Exception ex)
            {
                return "Hata olustu: " + ex.Message;
            }
        }
    }
}
