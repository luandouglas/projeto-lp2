using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations.Schema;

namespace Project.Models
{
    public class Camisa
    {
        public long Id { get; set; }

        public long RoupaId { get; set; }

        [ForeignKey("RoupaId")]
        public Roupa Roupa { get; set; }
        public int Quantidade { get; set; }
        public long CarrinhoId { get; set; }
        [JsonIgnore]
        [ForeignKey("CarrinhoId")]
        public Carrinho Carrinho { get; set; }
    }
}