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

        // Nuevo xd
        public async Task<List<CentroCostos>> GetCentroCostos()
        {

            // Send a GET request to the API
            HttpResponseMessage response = await httpClient.GetAsync(_baseURL + "api/Varios/CentroCostosSelect");

            // Ensure the request was successful
            if (response.IsSuccessStatusCode)
            {
                // Read the response content as a string
                string content = await response.Content.ReadAsStringAsync();

                // Deserialize the JSON string to a list of Producto objects
                List<CentroCostos> listaCentroCostos = JsonConvert.DeserializeObject<List<CentroCostos>>(content);

                return listaCentroCostos;
            }
            else
            {
                throw new Exception($"Error: {response.StatusCode}");
            }

        }

        public async Task<CentroCostos> InsertCentroCostos(CentroCostos newCentroCostos)
        {

            // Construir la URL con los parámetros
            string url = $"{_baseURL}api/Varios/CentroCostosInsert" +
                         $"?codigocentrocostos={newCentroCostos.Codigo}" +
                         $"&descripcioncentrocostos={Uri.EscapeDataString(newCentroCostos.NombreCentroCostos)}";

            // Send a POST request to the API with the constructed URL
            HttpResponseMessage response = await httpClient.PostAsync(url, null);

            // Ensure the request was successful
            if (response.IsSuccessStatusCode)
            {
                // Read the response content as a string
                string content = await response.Content.ReadAsStringAsync();

                // Deserialize the JSON string to a CentroCostos object
                List<CentroCostos> centroCostosInserted = JsonConvert.DeserializeObject<List<CentroCostos>>(content);

                return centroCostosInserted.ElementAt(0);
            }
            else
            {
                throw new Exception($"Error: {response.StatusCode}");
            }

        }


        public async Task<CentroCostos> DeleteCentroCostos(CentroCostos CentroCostosToDelete)
        {

            // Construir la URL con los parámetros
            string url = $"{_baseURL}api/Varios/CentroCostosDelete" +
                         $"?codigocentrocostos={CentroCostosToDelete.Codigo}" +
                         $"&descripcioncentrocostos={CentroCostosToDelete.NombreCentroCostos}";

            // Send a POST request to the API with the constructed URL
            HttpResponseMessage response = await httpClient.GetAsync(url);

            // Ensure the request was successful
            if (response.IsSuccessStatusCode)
            {
                // Read the response content as a string
                string content = await response.Content.ReadAsStringAsync();


                return null;
            }
            else
            {
                throw new Exception($"Error: {response.StatusCode}");
            }

        }

        public async Task UpdateCentroCostos(CentroCostos CentroCostosToUpdate)
        {

            // Construir la URL con los parámetros
            string url = $"{_baseURL}api/Varios/CentroCostosUpdate" +
                         $"?codigocentrocostos={CentroCostosToUpdate.Codigo}" +
                         $"&descripcioncentrocostos={Uri.EscapeDataString(CentroCostosToUpdate.NombreCentroCostos)}";

            // Send a POST request to the API with the constructed URL
            HttpResponseMessage response = await httpClient.GetAsync(url);

            // Ensure the request was successful
            if (response.IsSuccessStatusCode)
            {
                // Read the response content as a string
                string content = await response.Content.ReadAsStringAsync();

            }
            else
            {
                throw new Exception($"Error: {response.StatusCode}");
            }

        }

    }
}
