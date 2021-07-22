using MentoriaQuintaFeira2021.Contracts.Repositories;
using MentoriaQuintaFeira2021.EF;
using MentoriaQuintaFeira2021.Entities;

namespace MentoriaQuintaFeira2021.Repositories
{
    public class RepositorioCliente : RepositorioBase<Cliente>, IRepositorioCliente
    {
        private EFContext Context { get; set; }

        public RepositorioCliente(EFContext context) : base(context)
        {
            Context = context;
        }
    }
}
