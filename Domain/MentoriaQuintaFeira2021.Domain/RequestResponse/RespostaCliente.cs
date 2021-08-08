using MentoriaQuintaFeira2021.Domain.Entities;
using System.Collections.Generic;

namespace MentoriaQuintaFeira2021.Domain.RequestResponse
{
    public class RespostaCliente
    {

        public RespostaCliente() { }

        public RespostaCliente(Cliente cliente)
        {
            ID = cliente.ID;
            Nome = cliente.Nome;
        }

        public int ID { get; set; }
        public string Nome { get; set; }
    }
}
