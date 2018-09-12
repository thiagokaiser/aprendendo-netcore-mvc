using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SiteWeb.Models
{
    public class Teste
    {
        [Key]
        public int Id { get; set; }

        public string Descricao { get; set; }

        public string Nome { get; set; }
        
        public string Bunda { get; set; }

        public bool Ativo { get; set; }

    }
}
