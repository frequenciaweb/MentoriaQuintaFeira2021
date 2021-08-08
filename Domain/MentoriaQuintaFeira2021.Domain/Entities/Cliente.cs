using MentoriaQuintaFeira2021.Domain.VO;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MentoriaQuintaFeira2021.Domain.Entities
{
    public class Cliente
    {
        public int ID { get; set; }

        [Required(ErrorMessage = "Digite o nome")]
        public string Nome { get; set; }

        public VOEndereco Endereco { get; set; } = new VOEndereco();

        public List<Venda> Vendas { get; set; }
    }
}
