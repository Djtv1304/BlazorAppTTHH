using BlazorAppPrub.Models;
using Microsoft.JSInterop;
using Newtonsoft.Json;
using static System.Net.WebRequestMethods;

namespace BlazorAppPrub.APIService
{
    public class APIService : IAPIService
    {

        private static string _baseURL;

        HttpClient httpClient = new HttpClient();

        

        public APIService()
        {

            // URL de la API
            _baseURL = "http://apiservicios.ecuasolmovsa.com:3009/";

            httpClient.BaseAddress = new Uri(_baseURL);

        }

        public async Task<EmisorUsuario> UserAuthentication(string username, string password)
        {

            var url = $"{_baseURL}api/Usuarios?usuario={username}&password={password}";

            var response = await httpClient.GetAsync(url);

            if (response.IsSuccessStatusCode)
            {

                var result = await response.Content.ReadAsStringAsync();

                // Valido si mi JSON contiene un resultado de error

                if (result.Contains("error", StringComparison.OrdinalIgnoreCase))
                {

                    return null;

                }

                return JsonConvert.DeserializeObject<List<EmisorUsuario>>(result).FirstOrDefault();

            }

            return null;
        }

        public async Task<List<Emisor>> GetEmisor()
        {

            var url = $"{_baseURL}api/Varios/GetEmisor";

            var response = await httpClient.GetAsync(url);

            if (response.IsSuccessStatusCode)
            {

                var result = await response.Content.ReadAsStringAsync();

                return JsonConvert.DeserializeObject<List<Emisor>>(result).ToList();

            }

            return null;

        }

    }
}
