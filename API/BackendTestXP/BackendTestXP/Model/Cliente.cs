namespace XPTesteAPI.Entities
{
    public class Cliente
    {
        public int Id { get; set; }
        public string? Nome { get; set; }
        public string? Telefone { get; set; }
        public int? Idade { get; set; } = null;
        public virtual ICollection<Endereco>? Enderecos { get; set; }
        public virtual ICollection<Email>? Emails { get; set; }

    }
}
