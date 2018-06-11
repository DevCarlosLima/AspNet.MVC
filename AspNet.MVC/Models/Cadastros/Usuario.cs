using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace AspNet.MVC.Models.Cadastros
{
    public class Usuario
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MinLength(3)]
        [MaxLength(150)]
        public string Nome { get; set; }

        [Required]
        [MinLength(10)]
        [MaxLength(150)]
        [EmailAddress]
        [DisplayName("E-mail")]
        public string Email { get; set; }

        [Required]
        public bool Ativo { get; set; }

        [DisplayName("Data Cadastro")]
        public DateTime DataCadastro { get; set; }
    }
}