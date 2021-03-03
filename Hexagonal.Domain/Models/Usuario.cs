﻿using System;

namespace Hexagonal.Domain.Models
{
    public class Usuario
    {
        /// <summary>
        /// Identificador do usuário
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// Login do usuário
        /// </summary>
        public string Login { get; set; }

        /// <summary>
        /// Senha do usuário
        /// </summary>
        public string Senha { get; set; }
    }
}