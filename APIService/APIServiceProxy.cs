using BlazorAppPrub.Models;

namespace BlazorAppPrub.APIService
{
    public class APIServiceProxy : IAPIService
    {
        private readonly IAPIService _realAPIService;
        private readonly string _baseURL;
        private readonly ILogger<APIServiceProxy> _logger;

        public APIServiceProxy(ILogger<APIServiceProxy> logger, IConfiguration configuration)
        {
            _realAPIService = new APIService();
            _baseURL = configuration["APIServiceBaseURL"] ?? "http://apiservicios.ecuasolmovsa.com:3009/";
            _logger = logger;
        }

        public async Task<EmisorUsuario> UserAuthentication(string username, string password)
        {
            try
            {
                await LogRequest(nameof(UserAuthentication), $"Username: {username}");

                // Llamada al método real
                var result = await _realAPIService.UserAuthentication(username, password);

                await LogRequestSuccess(nameof(UserAuthentication));

                return result;
            }
            catch (Exception ex)
            {
                await LogRequestError(nameof(UserAuthentication), ex.Message);
                throw;
            }
        }

        public async Task<List<Emisor>> GetEmisor()
        {
            try
            {
                await LogRequest(nameof(GetEmisor));

                // Llamada al método real
                var result = await _realAPIService.GetEmisor();

                await LogRequestSuccess(nameof(GetEmisor));

                return result;
            }
            catch (Exception ex)
            {
                await LogRequestError(nameof(GetEmisor), ex.Message);
                throw;
            }
        }

        public async Task<List<CentroCostos>> GetCentroCostos()
        {
            try
            {
                await LogRequest(nameof(GetCentroCostos));

                // Llamada al método real
                var result = await _realAPIService.GetCentroCostos();

                await LogRequestSuccess(nameof(GetCentroCostos));

                return result;
            }
            catch (Exception ex)
            {
                await LogRequestError(nameof(GetCentroCostos), ex.Message);
                throw;
            }
        }

        public async Task<CentroCostos> InsertCentroCostos(CentroCostos newCentroCostos)
        {
            try
            {
                await LogRequest(nameof(InsertCentroCostos));

                // Llamada al método real
                var result = await _realAPIService.InsertCentroCostos(newCentroCostos);

                await LogRequestSuccess(nameof(InsertCentroCostos));

                return result;
            }
            catch (Exception ex)
            {
                await LogRequestError(nameof(InsertCentroCostos), ex.Message);
                throw;
            }
        }

        public async Task UpdateCentroCostos(CentroCostos centroCostosToUpdate)
        {
            try
            {
                await LogRequest(nameof(UpdateCentroCostos));

                // Llamada al método real
                await _realAPIService.UpdateCentroCostos(centroCostosToUpdate);

                await LogRequestSuccess(nameof(UpdateCentroCostos));
            }
            catch (Exception ex)
            {
                await LogRequestError(nameof(UpdateCentroCostos), ex.Message);
                throw;
            }
        }

        public async Task<CentroCostos> DeleteCentroCostos(CentroCostos centroCostosToDelete)
        {
            try
            {
                await LogRequest(nameof(DeleteCentroCostos));

                // Llamada al método real
                var result = await _realAPIService.DeleteCentroCostos(centroCostosToDelete);

                await LogRequestSuccess(nameof(DeleteCentroCostos));

                return result;
            }
            catch (Exception ex)
            {
                await LogRequestError(nameof(DeleteCentroCostos), ex.Message);
                throw;
            }
        }

        private async Task LogRequest(string method, string parameters = "")
        {
            // Lógica para registrar detalles de la llamada, por ejemplo, fecha, hora, duración, etc.
            _logger.LogInformation($"API Request - Method: {method}, Parameters: {parameters}");
        }

        private async Task LogRequestSuccess(string method)
        {
            _logger.LogInformation($"API Request successful - Method: {method}");
        }

        private async Task LogRequestError(string method, string errorMessage)
        {
            _logger.LogError($"API Request error - Method: {method}, Error: {errorMessage}");
        }
    }

}
