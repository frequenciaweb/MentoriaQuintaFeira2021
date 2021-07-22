using MentoriaQuintaFeira2021.Contracts.Repositories;
using MentoriaQuintaFeira2021.EF;
using MentoriaQuintaFeira2021.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace MentoriaQuintaFeira2021.Repositories
{
    public class RepositorioVenda : RepositorioBase<Venda>, IRepositorioVenda
    {
        private EFContext Context { get; set; }

        public RepositorioVenda(EFContext context) : base(context)
        {
            Context = context;
        }

        public override List<Venda> Obter()
        {
            return Context.Vendas.Include(x => x.Produto).Include(x => x.Cliente).ToList();
        }

        public override Venda Obter(int id)
        {
            return Context.Vendas.Include(x => x.Produto).Include(x => x.Cliente).FirstOrDefault(x => x.ID == id);
        }

        public void CancelarVenda(int id)
        {
            Context.Vendas.Remove(Context.Vendas.FirstOrDefault(x => x.ID == id));
        }

        public void FecharVenda(Venda venda)
        {
            Context.Vendas.Add(venda);
        }
    }
}
