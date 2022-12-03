using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace PjA2Tp3.Models
{
    [Table("Empresa")]
    [Index("Email", Name = "IX_Empresa", IsUnique = true)]
    [Index("Cnpj", Name = "IX_Empresa_1", IsUnique = true)]
    public partial class Empresa
    {
        public Empresa()
        {
            TelefoneUsuarioEmpresas = new HashSet<TelefoneUsuarioEmpresa>();
            Vagas = new HashSet<Vaga>();
        }

        [Key]
        public int Id { get; set; }
        public bool IsActive { get; set; }
        [StringLength(100)]
        public string NomeFantasia { get; set; } = null!;
        [StringLength(100)]
        public string Email { get; set; } = null!;
        [StringLength(50)]
        public string Password { get; set; } = null!;
        [StringLength(50)]
        public string InscricaoEstadual { get; set; } = null!;
        public int? EnderecoId { get; set; }
        [StringLength(14)]
        public string? Cnpj { get; set; }

        [ForeignKey("EnderecoId")]
        [InverseProperty("Empresas")]
        public virtual Endereco? Endereco { get; set; }
        [InverseProperty("Empresa")]
        public virtual ICollection<TelefoneUsuarioEmpresa> TelefoneUsuarioEmpresas { get; set; }
        [InverseProperty("PessoaJuridica")]
        public virtual ICollection<Vaga> Vagas { get; set; }
    }
}
