using BlazorAppPrub.Models;

namespace BlazorAppPrub.APIService
{
    public interface IAPIService
    {

        public Task<EmisorUsuario> UserAuthentication(string username, string password);

        public Task<List<Emisor>> GetEmisor();

        Task<List<CentroCostos>> GetCentroCostos();

        Task<CentroCostos> InsertCentroCostos(CentroCostos newCentroCostos);

        Task UpdateCentroCostos(CentroCostos CentroCostosToUpdate);

        Task<CentroCostos> DeleteCentroCostos(CentroCostos CentroCostosToDelete);

    }
}
