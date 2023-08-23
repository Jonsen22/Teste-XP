using BackendTestXP.Model;
using BackendTestXP.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;
using XPTesteAPI.Entities;

namespace BackendTestXP.Repository
{
    public class EmailRepository : BaseRepository, IEmailRepository
    {
        private readonly AppDbContext _context;
        public EmailRepository(AppDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<Email> GetEmailById(int id)
        {
            return await _context.Email
                .Where(e => e.Id == id)
                .FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<Email>> GetEmails()
        {
            return await _context.Email.ToListAsync();
        }
    }
}
