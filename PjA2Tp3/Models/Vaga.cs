using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace PjA2Tp3.Models
{
    [Table("Vaga")]
    public partial class Vaga
    {

        [Key]
        public int Id { get; set; }

        [StringLength(100)]
        public string Titulo { get; set; } 

        [StringLength(1000)]
        public string Descricao { get; set; }

        [Column(TypeName = "decimal(18, 2)")]
        public decimal Remuneracao { get; set; }

        public int Curtidas { get; set; } = 0;

        public Turno Turno { get; set; }

        public Modalidade Modalidade { get; set; }

        public int? EmpresasId { get; set; }

        public Empresa Empresas { get; set; }   

        public virtual IList<VagaTag> Tags { get; set; }

    }
}
