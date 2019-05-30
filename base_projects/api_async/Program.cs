using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;


namespace api_async
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }

        static async Task RunAsync()
        {
              using (var client = new HttpClient())
            {
              // New code:
             client.BaseAddress = new Uri("http://localhost:9000/");
             client.DefaultRequestHeaders.Accept.Clear();
             client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
           
            HttpResponseMessage response = await client.GetAsync("api/products/1");
            if (response.IsSuccessStatusCode)
                {
                    Product product = await response.Content.ReadAsAsync>Product>();
                 Console.WriteLine("{0}\t${1}\t{2}", product.Name, product.Price, product.Category);
                 }
           
            }
        }
    }

    class Product{
        public string Name {get;set;}
        public double Price {get; set;}
        public string Category {get; set;}
    }
}
