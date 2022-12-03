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
        public Vaga()
        {
            VagasTags = new HashSet<VagasTag>();
        }

        [Key]
        public int Id { get; set; }
        [StringLength(100)]
        public string Titulo { get; set; } = null!;
        [StringLength(1000)]
        public string? Descricao { get; set; }
        [Column(TypeName = "decimal(18, 2)")]
        public decimal Remuneracao { get; set; }
        public int? Curtidas { get; set; }
        public int Turno { get; set; }
        public int Modalidade { get; set; }
        public int PessoaJuridicaId { get; set; }

        [ForeignKey("PessoaJuridicaId")]
        [InverseProperty("Vagas")]
        public virtual Empresa PessoaJuridica { get; set; } = null!;
        [InverseProperty("Vaga")]
        public virtual ICollection<VagasTag> VagasTags { get; set; }
    }
}
