

namespace BackendTestXP.DTOs
{
    public class EnderecoDTO
    {
        public int Id { get; set; }
        public bool? Principal { get; set; }
        public string? Rua { get; set; }
        public string? Numero { get; set; }
        public string? Cidade { get; set; }
        public string? Estado { get; set; }
        public string? Cep { get; set; }
        public int ClienteId { get; set; }
    }
}
