using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading.Tasks;

namespace Project.Models
{
    public class Loja
    {
        Loja()
        {
            Compras = new List<Carrinho>();
            Roupas = new List<Roupa>();
        }

        [Key]
        public long Id { get; set; }
        [Required]
        public string Nome { get; set; }
        [Required]
        public string Endereco { get; set; }

        public virtual ICollection<Roupa> Roupas { get; set; }
        public virtual ICollection<Carrinho> Compras { get; set; }
    }
}
