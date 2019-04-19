using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Project.Models
{
    public class Carrinho
    {
        Carrinho()
        {
            Camisas = new List<Camisa>();
        }
        [Key]
        public long Id { get; set; }

        [ForeignKey("LojaId")]
        public long LojaId { get; set; }
        public virtual ICollection<Camisa> Camisas { get; set; }


    }

}
