using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Livraria.Servico.Models
{
    public class LivroAlterarModel
    {
        [Required(ErrorMessage = "O ISBN é obrigatório.")]
        [MinLength(13, ErrorMessage = "Por favor, informe o ISBN com {1} dígitos.")]
        [MaxLength(13, ErrorMessage = "Por favor, informe o ISBN com {1} dígitos.")]
        public string ISBN { get; set; }

        [Required(ErrorMessage = "O autor é obrigatório.")]
        [MinLength(5, ErrorMessage = "Informe no mínimo {1} caracteres.")]
        [MaxLength(100, ErrorMessage = "Informe no máximo {1} caracteres.")]
        public string Autor { get; set; }

        [Required(ErrorMessage = "O nome do livro é obrigatório.")]
        [MinLength(5, ErrorMessage = "Informe no mínimo {1} caracteres.")]
        [MaxLength(100, ErrorMessage = "Informe no máximo {1} caracteres.")]
        public string Nome { get; set; }

        [Required]
        [RegularExpression(@"^\d+.?\d{0,2}$", ErrorMessage = "Preço inválido, máximo de duas casas decimais.")]
        [Range(0.01, 9999999999999999.99, ErrorMessage = "Preço inválido")]
        public decimal Preco { get; set; }

        [Required(ErrorMessage = "A data de publicação é obrigatória.")]
        public DateTime DtPublicacao { get; set; }

        [MaxLength(100, ErrorMessage = "Informe no máximo {1} caracteres.")]
        public string DescImagemCapa { get; set; }

        public string ImagemCapa { get; set; }

    }
}