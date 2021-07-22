using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MentoriaQuintaFeira2021.Entities
{
    public class Cliente
    {
        public int ID { get; set; }

        [Required(ErrorMessage = "Digite o nome")]
        public string Nome { get; set; }

        public List<Venda> Vendas { get; set; }
    }
}
