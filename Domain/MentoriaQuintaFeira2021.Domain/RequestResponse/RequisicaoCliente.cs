using MentoriaQuintaFeira2021.Domain.Entities;

namespace MentoriaQuintaFeira2021.Domain.RequestResponse
{
    public class RequisicaoCliente
    {
        public string Nome { get; set; }

        public static implicit operator Cliente(RequisicaoCliente request )
        {
            return new Cliente
            {
                Nome = request.Nome
            };
        }

    }
}
