using System;

namespace MentoriaQuintaFeira2021.Entities
{
    public class Venda
    {
        public int ID { get; set; }

        public DateTime Data { get; set; }

        public int ClienteID { get; set; }
        public Cliente Cliente { get; set; }

        public int ProdutoID { get; set; }
        public Produto Produto { get; set; }

        public int Quantidade { get; set; }

        public decimal Valor { get; set; }

        public decimal ValorTotal { get; set; }

    }
}
