using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Project.Models
{
    public class Roupa
    {
        [Key]
        public long Id { get; set; }
        public string Marca { get; set; }
        public char Tamanho { get; set; }
        public char Sexo { get; set; }
        [Column(TypeName = "decimal(18, 2)")]
        public decimal Preco { get; set; }
        [Required]
        public long Quantidade { get; set; }
        [ForeignKey("LojaId")]
        public long? LojaId { get; set; }
        [JsonIgnore]
        public ICollection<Camisa> Camisas { get; set; }


    }
}
