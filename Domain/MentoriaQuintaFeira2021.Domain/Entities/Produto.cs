using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MentoriaQuintaFeira2021.Domain.Entities
{
    public class Produto
    {
        public int ID { get; set; }

        [Required(ErrorMessage = "Digite a descrição")]
        public string Descricao { get; set; }

        [Range(0, 999, ErrorMessage = "Valor deve ser inferior a R$999,00")]
        public decimal Valor { get; set; }

        [Required(ErrorMessage = "Digite a categoria")]
        public string Categoria { get; set; }

        [Required(ErrorMessage = "Digite a quantidade")]
        public int Quantidade { get; set; }

        public List<Venda> Vendas { get; set; }

        [NotMapped]
        public bool Disponivel
        {
            get { return Quantidade > 0; }
        }
    }
}
