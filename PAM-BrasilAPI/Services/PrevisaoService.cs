using PAM_BrasilAPI.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace PAM_BrasilAPI.Services
{
    public class PrevisaoService
    {
        private HttpClient httpClient;
        private JsonSerializerOptions jsonSerializerOptions;

        public PrevisaoService()
        {
            httpClient = new HttpClient();
            jsonSerializerOptions = new JsonSerializerOptions
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
                WriteIndented = true
            };
        }
        public async Task<Previsao> getPrevisaoById(int id)
        {
            Uri uri = new Uri("https://brasilapi.com.br/api/cptec/v1/clima/previsao/{id}");
            Previsao items = new Previsao();

            try
            {
                HttpResponseMessage response = await httpClient.GetAsync(uri);
                if (response.IsSuccessStatusCode)
                {
                    string content = await response.Content.ReadAsStringAsync();
                    items = JsonSerializer.Deserialize<Previsao>(content, jsonSerializerOptions);
                }
            }
            catch(Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }
                return items;
            }
    }
}
