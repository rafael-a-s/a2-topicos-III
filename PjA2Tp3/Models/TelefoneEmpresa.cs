using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace PjA2Tp3.Models
{
    [Table("TelefoneEmpresa")]
    public partial class TelefoneEmpresa
    {
        [Key]
        public int Id { get; set; }
        [StringLength(2)]
        public string Ddd { get; set; } = null!;
        [StringLength(9)]
        public string? Numero { get; set; }

        public int EmpresaId { get; set; }
        public Empresa Empresa { get; set; }

    }
}
