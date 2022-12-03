using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace PjA2Tp3.Models
{
    [Table("Usuario")]
    [Index("Cpf", Name = "IX_Cpf", IsUnique = true)]
    [Index("Email", Name = "IX_Email", IsUnique = true)]
    public partial class Usuario
    {
        public Usuario()
        {
            Enderecos = new HashSet<Endereco>();
            TelefoneUsuarioEmpresas = new HashSet<TelefoneUsuarioEmpresa>();
        }

        [Key]
        public int Id { get; set; }
        public bool IsActive { get; set; }
        [StringLength(255)]
        public string Nome { get; set; } = null!;
        [StringLength(255)]
        public string Email { get; set; } = null!;
        [StringLength(20)]
        public string Password { get; set; } = null!;
        public int? Perfil { get; set; }
        [StringLength(11)]
        public string? Cpf { get; set; }
        public int? Sexo { get; set; }

        [InverseProperty("Pessoa")]
        public virtual ICollection<Endereco> Enderecos { get; set; }
        [InverseProperty("Usuario")]
        public virtual ICollection<TelefoneUsuarioEmpresa> TelefoneUsuarioEmpresas { get; set; }
    }
}
