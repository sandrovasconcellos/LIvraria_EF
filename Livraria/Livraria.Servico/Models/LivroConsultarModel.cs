using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Livraria.Servico.Models
{
    public class LivroConsultarModel
    {      
        public string ISBN { get; set; }
        public string Autor { get; set; }
        public string Nome { get; set; }
        public decimal Preco { get; set; }
        public DateTime DtPublicacao { get; set; }
        public string DescImagemCapa { get; set; }
        public string ImagemCapa { get; set; }
    }
}