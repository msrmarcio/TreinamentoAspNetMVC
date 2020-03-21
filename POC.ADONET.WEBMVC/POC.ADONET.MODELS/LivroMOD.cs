using System.ComponentModel.DataAnnotations;

namespace POC.ADONET.MODELS
{
    public class LivroMOD
    {
        [Required(ErrorMessage ="O Id ou codigo  é obrigatório")]
        [Display(Name ="Código")]
        public string Id { get; set; }

        [Required(ErrorMessage ="Por favor Preencher o título do livro")]
        [StringLength(100, ErrorMessage ="O nome do livro permite a qtde. máxima de {1} caracteres")]
        [Display(Name ="Título:")]
        public string Titulo { get; set; }

        [Display(Name = "Assunto/Segmento:")]
        public string Tipo { get; set; }

        // colocamos interrogacao para marcar que esta prop pode aceitar NULL
        [Display(Name = "Preço R$:")]
        public decimal? Preco { get; set; }

        [Required(ErrorMessage = "Por favor preencher a resenha.")]
        [StringLength(50, ErrorMessage = "A resenha somente permite a quantidade de {1} caracteres.")]
        [Display(Name = "Resenha:")]
        public string Resenha { get; set; }

    }
}
