using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POC.ADONET.MODELS
{
    public class LivroMOD
    {
        [Display(Name ="Código")]
        public string Id { get; set; }

        public string Titulo { get; set; }
        public string Tipo { get; set; }

        // colocamos interrogacao para marcar que esta prop
        // pode aceitar NULL
        public decimal? Preco { get; set; }
        public string Resenha { get; set; }

    }
}
