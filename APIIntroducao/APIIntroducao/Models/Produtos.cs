using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace APIIntroducao.Models
{
    public class Produtos
    {
        public int Id { get; set; }
        public string Nome { get; set; }

        [ForeignKey("Categoria")]
        public int CategoriaId { get; set; }

        public Categoria Categoria { get; set; }
           

    }
}
