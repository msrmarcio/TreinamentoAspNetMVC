using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ViagensOnline.Cap4Lab1.Web.Models
{
    public class Destino
    {
        public int DestinoId { get; set; }
        [Required]
        public string Nome { get; set; }
        [Required]
        public string Pais { get; set; }
        [Required]
        public string Cidade { get; set; }
        [Required]
        [Display(Name ="Selecione a foto")]
        public string Foto { get; set; }
    }
}

