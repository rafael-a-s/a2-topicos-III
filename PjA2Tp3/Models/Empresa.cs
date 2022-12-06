using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace PjA2Tp3.Models
{
    [Table("Empresa")]
    public partial class Empresa
    {
      

        [Key]
        public int Id { get; set; }

        public bool IsActive { get; set; }

        [Required(ErrorMessage = "Informe o nome")]
        [MaxLength(100, ErrorMessage = "Informe no máximo 100 caracteres")]
        [MinLength(0)]
        public string NomeFantasia { get; set; }

        [Required(ErrorMessage = "Informe o email")]
        [MaxLength(255, ErrorMessage = "Informe no máximo 255 caracteres")]
        [MinLength(0)]
        [EmailAddress(ErrorMessage = "Informe um email válido")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Informe sua senha")]
        [MaxLength(50, ErrorMessage = "Informe no máximo 50 caracteres")]
        [MinLength(3, ErrorMessage = "Informa no mínimo 3 caracteres")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Informe o IE")]
        [MaxLength(14, ErrorMessage = "Informe no máximo 14 caracteres")]
        [MinLength(0)]
        public string InscricaoEstadual { get; set; }

        [Required(ErrorMessage = "Informe o CNPJ")]
        [MaxLength(14, ErrorMessage = "Informe no máximo 14 caracteres")]
        [MinLength(0)]
        public string Cnpj { get; set; }

        public IList<TelefoneEmpresa> Telefones { get; set; }

        public IList<EnderecoEmpresa> Enderecos { get; set; }
        
        public virtual IList<Vaga> Vagas { get; set; }
    }
}
