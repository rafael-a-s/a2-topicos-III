using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace PjA2Tp3.Models
{
    [Table("Tag")]
    public partial class Tag
    {
        public Tag()
        {
            VagasTags = new HashSet<VagasTag>();
        }

        [Key]
        public int Id { get; set; }
        [StringLength(50)]
        public string Label { get; set; } = null!;

        [InverseProperty("Tag")]
        public virtual ICollection<VagasTag> VagasTags { get; set; }
    }
}
