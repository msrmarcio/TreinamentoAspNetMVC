using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Portfolio.Cap3.Lab01.Models
{
    public class Cliente
    {
        [Key]
        public int IdCliente { get; set; }

        [Required]
        [StringLength(30, ErrorMessage = "Tamanho máximo: 30 caracteres")]
        [Display(Name = "Nome do Cliente")]
        public string Name { get; set; }

        [Display(Name = "Pessoa Juridica")]
        public bool PJ { get; set; }

    }
}