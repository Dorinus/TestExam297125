using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using AuthorApi.Models;

namespace AuthorBlazor.Data
{
    public class AuthorManager : IAuthorManager
    {
        
        private HttpClient Client;
        private String Uri;

        public AuthorManager()
        {
            Client = new HttpClient();
            Uri = "https://localhost:5003";
        }
        
        public async Task<Author> createAuthor(Author author)
        {
            String productAsJson = JsonSerializer.Serialize(author);
            StringContent content = new StringContent(productAsJson, Encoding.UTF8, "application/json");
            HttpResponseMessage responseMessage = await Client.PostAsync(Uri + "/author",  content);
            if (responseMessage.IsSuccessStatusCode)
            {
                
                string result = await responseMessage.Content.ReadAsStringAsync();
                Author authorCreatead = JsonSerializer.Deserialize<Author>(result,
                    new JsonSerializerOptions {PropertyNamingPolicy = JsonNamingPolicy.CamelCase});
                return authorCreatead;
            }
            else
            {
                Console.WriteLine($@"Error: {responseMessage.StatusCode}, {responseMessage.ReasonPhrase}");
                return null;
            }
        }

        public async Task<IList<Author>> getAuthots()
        {
            HttpResponseMessage responseMessage = await Client.GetAsync(Uri + "/author/" );
            if (responseMessage.IsSuccessStatusCode)
            {
                string result = await responseMessage.Content.ReadAsStringAsync();
                IList<Author> authors = JsonSerializer.Deserialize<IList<Author>>(result,
                    new JsonSerializerOptions {PropertyNamingPolicy = JsonNamingPolicy.CamelCase});
                return authors;
            }
            else
            {
                Console.WriteLine($@"Error: {responseMessage.StatusCode}, {responseMessage.ReasonPhrase}");
                return null;
            }
        }
    }
}