using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using userApi.ForiegnDtos;

namespace Data.Repositry
{
    public class FillialeRepository
    {
        HttpClient _httpClient = new HttpClient();
        public FillialeDto GetSubsidiaryById(Guid fillialeId)
        {
            HttpResponseMessage response = _httpClient.GetAsync("http://localhost:44349/api/Filliale/"+fillialeId).Result;
            response.EnsureSuccessStatusCode();
            System.Console.WriteLine("response.Headers: " + response.Headers.ToString());
            var responseBody = response.Content.ReadAsStringAsync().Result;
            return JsonConvert.DeserializeObject<FillialeDto>(responseBody);
           
        }
    }
}
