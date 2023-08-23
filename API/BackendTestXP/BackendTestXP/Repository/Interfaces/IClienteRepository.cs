using BackendTestXP.DTOs;
using XPTesteAPI.Entities;

namespace BackendTestXP.Repository.Interfaces
{
    public interface IClienteRepository : IBaseRepository
    {
        Task<IEnumerable<Cliente>> GetClientes();
        Task<IEnumerable<Cliente>> GetClientesDetalhes();
        Task<Cliente> GetClienteById(int id);
        Task<Cliente> GetClientesDetalhesById(int id);
    }
}
