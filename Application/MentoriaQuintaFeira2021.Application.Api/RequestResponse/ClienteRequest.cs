using MentoriaQuintaFeira2021.Domain.Entities;

namespace MentoriaQuintaFeira2021.Application.Api.RequestResponse
{
    public class ClienteRequest
    {
        public string Nome { get; set; }

        public static implicit operator Cliente(ClienteRequest request )
        {
            return new Cliente
            {
                Nome = request.Nome
            };
        }

    }
}
