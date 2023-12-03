using BlazorAppPrub.Models;

namespace BlazorAppPrub.APIService
{
    public interface IAPIService
    {

        public Task<EmisorUsuario> UserAuthentication(string username, string password);

        public Task<List<Emisor>> GetEmisor();

    }
}
