using XPTesteAPI.Entities;

namespace BackendTestXP.Repository.Interfaces
{
    public interface IEnderecoRepository : IBaseRepository
    {
        Task<IEnumerable<Endereco>> GetEnderecos();
        Task<Endereco> GetEnderecoById(int id);
    }
}
