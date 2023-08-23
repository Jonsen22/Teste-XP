using XPTesteAPI.Entities;

namespace BackendTestXP.Repository.Interfaces
{
    public interface IEmailRepository : IBaseRepository
    {
        Task<IEnumerable<Email>> GetEmails();
        Task<Email> GetEmailById(int id);
    }
}
