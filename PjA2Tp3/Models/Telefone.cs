using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace PjA2Tp3.Models
{
    [Table("Telefone")]
    public partial class Telefone
    {
        public Telefone()
        {
            TelefoneUsuarioEmpresas = new HashSet<TelefoneUsuarioEmpresa>();
        }

        [Key]
        public int Id { get; set; }
        [StringLength(2)]
        public string Ddd { get; set; } = null!;
        [StringLength(9)]
        public string? Numero { get; set; }

        [InverseProperty("Telefone")]
        public virtual ICollection<TelefoneUsuarioEmpresa> TelefoneUsuarioEmpresas { get; set; }
    }
}
