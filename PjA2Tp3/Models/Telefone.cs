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
        [Key]
        public int Id { get; set; }
        [StringLength(2)]
        public string Ddd { get; set; } = null!;
        [StringLength(9)]
        public string Numero { get; set; }

        public int UsuarioId { get; set; }  

        public Usuario Usuario { get; set;}

    }
}
