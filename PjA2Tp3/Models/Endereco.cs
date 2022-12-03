using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace PjA2Tp3.Models
{
    [Table("Endereco")]
    public partial class Endereco
    {
        public Endereco()
        {
            Empresas = new HashSet<Empresa>();
        }

        [Key]
        public int Id { get; set; }
        [StringLength(255)]
        public string? Bairro { get; set; }
        [StringLength(255)]
        public string? Logradouro { get; set; }
        [StringLength(255)]
        public string? TipoLogradouro { get; set; }
        [StringLength(50)]
        public string? Cidade { get; set; }
        [StringLength(50)]
        public string? Estado { get; set; }
        public int? PessoaId { get; set; }

        [ForeignKey("PessoaId")]
        [InverseProperty("Enderecos")]
        public virtual Usuario? Pessoa { get; set; }
        [InverseProperty("Endereco")]
        public virtual ICollection<Empresa> Empresas { get; set; }
    }
}
