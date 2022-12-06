using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace PjA2Tp3.Models
{
    [Table("EnderecoEmpresa")]
    public partial class EnderecoEmpresa
    {

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

        public int EmpresaId { get; set; }

        public virtual Empresa Empresa { get; set; }
       
    }
}
