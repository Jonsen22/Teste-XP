
using XPTesteAPI.Entities;

namespace BackendTestXP.DTOs
{
    public class EmailDTO
    {
        public int Id { get; set; }
        public string EnderecoEmail { get; set; }
        public bool Principal { get; set; }
        public int ClienteId { get; set; }
    }
}
