using XPTesteAPI.Entities;

namespace BackendTestXP.DTOs
{
    public class ClienteDetalhesDTO
    {
        public int Id { get; set; }
        public string? Nome { get; set; }
        public string? Telefone { get; set; }
        public int? Idade { get; set; }
        public IEnumerable<EnderecoDTO> Enderecos { get; set; }
        public IEnumerable<EmailDTO> Emails { get; set; }
    }
}
