using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace PjA2Tp3.Models
{
    [Table("Telefone_Usuario_Empresa")]
    public partial class TelefoneUsuarioEmpresa
    {
        [Key]
        public int Id { get; set; }
        public int? UsuarioId { get; set; }
        public int? EmpresaId { get; set; }
        public int TelefoneId { get; set; }

        [ForeignKey("EmpresaId")]
        [InverseProperty("TelefoneUsuarioEmpresas")]
        public virtual Empresa? Empresa { get; set; }
        [ForeignKey("TelefoneId")]
        [InverseProperty("TelefoneUsuarioEmpresas")]
        public virtual Telefone Telefone { get; set; } = null!;
        [ForeignKey("UsuarioId")]
        [InverseProperty("TelefoneUsuarioEmpresas")]
        public virtual Usuario? Usuario { get; set; }
    }
}
