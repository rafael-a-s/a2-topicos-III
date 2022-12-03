using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace PjA2Tp3.Models
{
    [Table("Vagas_tags")]
    public partial class VagasTag
    {
        [Key]
        public int Id { get; set; }
        public int VagaId { get; set; }
        public int TagId { get; set; }

        [ForeignKey("TagId")]
        [InverseProperty("VagasTags")]
        public virtual Tag Tag { get; set; } = null!;
        [ForeignKey("VagaId")]
        [InverseProperty("VagasTags")]
        public virtual Vaga Vaga { get; set; } = null!;
    }
}
