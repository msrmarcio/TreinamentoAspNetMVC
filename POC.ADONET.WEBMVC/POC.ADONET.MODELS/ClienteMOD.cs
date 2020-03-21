using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POC.ADONET.MODELS
{
    public class ClienteMOD
    {
        public int Id { get; set; }

        [StringLength(100, ErrorMessage = "O nome permite a qtde. maxima de {1} caracteres")]
        public string Nome { get; set; }

        [EmailAddress(ErrorMessage = "O Email não é valido")]
        [StringLength(100, ErrorMessage = "O Email permite a qtde. maxima de {1} caracteres")]
        public string Email { get; set; }
        public string Observacao { get; set; }
    }
}
