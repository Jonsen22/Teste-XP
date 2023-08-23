using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace XPTesteAPI.Entities
{
    [ApiExplorerSettings(IgnoreApi = true)]
    public class Email
    {
        public int Id { get; set; }
        public string EnderecoEmail { get; set; }
        public bool Principal { get; set; } 

        [ForeignKey("ClienteId")]
        [Required]
        public int ClienteId { get; set; }
        [JsonIgnore]
        public Cliente? Cliente { get; set; } 
    }
}
