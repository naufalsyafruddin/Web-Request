using System;
using System.IO;
using System.Net;
using Newtonsoft.Json.Linq;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // URL untuk mengambil data universitas di Indonesia
            string url = "http://universities.hipolabs.com/search?country=Indonesia";

            // Membuat WebRequest
            WebRequest request = WebRequest.Create(url);

            // Mendapatkan respon dari request
            WebResponse response = request.GetResponse();

            // Menampilkan status dari respon
            Console.WriteLine("Status Code: " + ((HttpWebResponse)response).StatusCode);

            // Membaca konten dari respon
            using (Stream dataStream = response.GetResponseStream())
            {
                // Membuat stream reader untuk membaca respon
                StreamReader reader = new StreamReader(dataStream);

                // Membaca seluruh konten
                string responseFromServer = reader.ReadToEnd();

                // Parsing respon JSON
                JArray jsonResponse = JArray.Parse(responseFromServer);

                // Menampilkan data yang telah diparse
                Console.WriteLine(jsonResponse.ToString());
            }

            // Menutup respon
            response.Close();
        }
        catch (WebException webEx)
        {
            Console.WriteLine("WebException occurred: " + webEx.Message);
        }
        catch (Exception ex)
        {
            Console.WriteLine("An error occurred: " + ex.Message);
        }

        // Menjaga jendela konsol tetap terbuka
        Console.WriteLine("Press Enter to exit...");
        Console.ReadLine();
    }
}
