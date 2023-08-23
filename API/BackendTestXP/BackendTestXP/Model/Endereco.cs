using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace XPTesteAPI.Entities
{
    [ApiExplorerSettings(IgnoreApi = true)]
    public class Endereco
    {

        public int Id { get; set; }
        public bool? Principal { get; set; } 
        public string? Rua { get; set; } = null;
        public string? Numero { get; set; } = null;
        public string? Cidade { get; set; } = null;
        public string? Estado { get; set; } = null;
        public string? Cep { get; set; } = null;

        [ForeignKey("ClienteId")]
        [Required]
        public int ClienteId { get; set; }
        [JsonIgnore]
        public Cliente? Cliente { get; set; }

    }
}
