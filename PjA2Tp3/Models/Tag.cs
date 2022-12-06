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

        [Key]
        public int Id { get; set; }
        [StringLength(50)]
        public string Label { get; set; } 

        public virtual IList<VagaTag>? Vagas{ get; set; }    

    }
}
