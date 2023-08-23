
using XPTesteAPI.Entities;

namespace BackendTestXP.DTOs
{
    public class EmailAdicionarDTO
    {
        public string EnderecoEmail { get; set; }
        public bool Principal { get; set; }
        public int ClienteId { get; set; }
    }
}
