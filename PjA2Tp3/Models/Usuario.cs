using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace PjA2Tp3.Models
{
    [Table("Usuario")]
    public partial class Usuario
    {
        
        [Key]
        public int Id { get; set; }

        public bool IsActive { get; set; } = true;

        [Required(ErrorMessage = "Informe o nome")]
        [MaxLength(50, ErrorMessage = "Informe no máximo 50 caracteres")]
        [MinLength(0)]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Informe o email")]
        [MaxLength(255, ErrorMessage = "Informe no máximo 255 caracteres")]
        [MinLength(0)]
        [EmailAddress(ErrorMessage = "Informe um email válido")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Informe sua senha")]
        [MaxLength(50, ErrorMessage = "Informe no máximo 50 caracteres")]
        [MinLength(3, ErrorMessage ="Informa no mínimo 3 caracteres")]
        public string Password { get; set; }

        public Perfil Perfil { get; set; }

        [Required(ErrorMessage = "Informe o CPF")]
        [MaxLength(14, ErrorMessage = "Informe no máximo 14 caracteres")]
        [MinLength(0)]
        public string? Cpf { get; set; }

        [Required(ErrorMessage = "Informe a data de nascimento")]
        public DateTime DataNascimento { get; set; }

        public Sexo? Sexo { get; set; }

        public IList<Endereco>? Enderecos { get; set; }

        
        public virtual IList<Telefone> Telefones { get; set; }
    }
}
