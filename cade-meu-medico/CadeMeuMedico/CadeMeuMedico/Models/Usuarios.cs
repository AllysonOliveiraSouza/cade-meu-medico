﻿using CadeMeuMedico.Context;

namespace CadeMeuMedico.Models
{
    public class Usuarios
    {
        public int Id { get; set; }
        public string? Nome { get; set; }
        public string? Login { get; set; }
        public string? Senha { get; set; }
        public string? Email { get; set; }

    }
}
