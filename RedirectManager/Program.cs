using System.Collections.Generic;
using System.IO;
using System.Net;

namespace RedirectManager
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] decodedUrls = System.IO.File.ReadAllLines(@"D:\test.txt");
            List<string> encodedUrls = new List<string>();
            TextWriter tw = new StreamWriter(@"D:\output.txt");

            for (var i = 0; i < decodedUrls.Length; i++)
            {
                var line = decodedUrls[i];
                string[] splitUrl = line.Split(new char[] { ',' }, 2);

                var oldUrl = splitUrl[0] + "=";
                var encodedUrl = WebUtility.UrlEncode(splitUrl[1]);

                var finalString = oldUrl + encodedUrl + "&";

                if (decodedUrls.Length == i + 1)
                {
                    finalString = oldUrl + encodedUrl;
                }

                encodedUrls.Add(finalString);
            }

            foreach (var encodedUrl in encodedUrls)
            {
                tw.WriteLine(encodedUrl);
            }
            tw.Close();
        }
    }
}