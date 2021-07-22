using System.Collections.Generic;

namespace MentoriaQuintaFeira2021.Contracts.Repositories
{
    public interface IRepositorioBase<TEntity> where TEntity : class
    {
        TEntity Incluir(TEntity entity);
        TEntity Alterar(TEntity entity);
        void Excluir(TEntity entity);
        TEntity Obter(int id);
        List<TEntity> Obter();
    }
}
