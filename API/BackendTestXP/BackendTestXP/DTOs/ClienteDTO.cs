﻿using XPTesteAPI.Entities;

namespace BackendTestXP.DTOs
{
    public class ClienteDTO
    {
        public int Id { get; set; }
        public string? Nome { get; set; }
        public string? Telefone { get; set; } 
        public int? Idade { get; set; }

    }
}
