using MentoriaQuintaFeira2021.Domain.Entities;
using System.Collections.Generic;

namespace MentoriaQuintaFeira2021.Application.Api.RequestResponse
{
    public class ClienteResponse
    {

        public ClienteResponse() { }

        public ClienteResponse(Cliente cliente)
        {
            ID = cliente.ID;
            Nome = cliente.Nome;
        }

        public int ID { get; set; }
        public string Nome { get; set; }
    }
}
