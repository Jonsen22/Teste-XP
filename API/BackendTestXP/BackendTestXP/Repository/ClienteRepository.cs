using BackendTestXP.DTOs;
using BackendTestXP.Model;
using BackendTestXP.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;
using XPTesteAPI.Entities;

namespace BackendTestXP.Repository
{
    public class ClienteRepository : BaseRepository, IClienteRepository
    {
        private readonly AppDbContext _context;
        public ClienteRepository(AppDbContext context) : base(context)
        {
            _context = context;
        }
     
        public async Task<Cliente> GetClienteById(int id)
        {
            return await _context.Cliente
                .Where(c => c.Id == id)
                .FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<Cliente>> GetClientes()
        {
            return await _context.Cliente.ToListAsync();
        }

        public async Task<IEnumerable<Cliente>> GetClientesDetalhes()
        {
            return await _context.Cliente
                .Include(c => c.Emails)
                .Include(c => c.Enderecos)
                .ToListAsync();
        }

        public async Task<Cliente> GetClientesDetalhesById(int id)
        {
            return await _context.Cliente
                .Include(c => c.Emails)
                .Include(c => c.Enderecos)
                .Where(c => c.Id == id).FirstOrDefaultAsync();
        }

        public bool Add(Cliente cliente)
        {
            _context.Add(cliente);
            var saved = _context.SaveChanges();
            return saved > 0 ? true : false;
        }

    }
}
