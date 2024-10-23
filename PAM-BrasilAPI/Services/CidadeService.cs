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
    public class CidadeService
    {
        private HttpClient httpClient;
        private Cidade cidade;
        private JsonSerializerOptions jsonSerializerOptions;
        private List<Cidade> cidades;

        public CidadeService()
        {
            httpClient = new HttpClient();
            jsonSerializerOptions = new JsonSerializerOptions
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
                WriteIndented = true
            };
        }

        public async Task<ObservableCollection<Cidade>> getCidades()
        {
            Uri uri = new Uri("https://brasilapi.com.br/api/cptec/v1/cidade/{cityName}");
            ObservableCollection<Cidade> cidades = new ObservableCollection<Cidade>();

            try
            {
                HttpResponseMessage response = await httpClient.GetAsync(uri);
                if (response.IsSuccessStatusCode)
                {
                    string content = await response.Content.ReadAsStringAsync();
                    cidades = JsonSerializer.Deserialize<ObservableCollection<Cidade>>(content, jsonSerializerOptions);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }
        }
    }
}
