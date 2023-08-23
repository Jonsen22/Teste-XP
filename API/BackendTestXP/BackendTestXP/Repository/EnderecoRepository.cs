using BackendTestXP.Model;
using Microsoft.EntityFrameworkCore;
using XPTesteAPI.Entities;

namespace BackendTestXP.Repository.Interfaces
{
    public class EnderecoRepository : BaseRepository, IEnderecoRepository
    {
        private readonly AppDbContext _context;
        public EnderecoRepository(AppDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Endereco>> GetEnderecos()
        {
            return await _context.Endereco.ToListAsync();
        }
        public async Task<Endereco> GetEnderecoById(int id)
        {
            return await _context.Endereco
              .Where(c => c.Id == id)
              .FirstOrDefaultAsync();
        }


    }
}
