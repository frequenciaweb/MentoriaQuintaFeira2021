namespace MentoriaQuintaFeira2021.Contracts.Services
{
    public interface IServicoBase<TEntity> where TEntity : class
    {
        TEntity Incluir(TEntity entity);
        TEntity Alterar(TEntity entity);
        void Excluir(TEntity entity);
    }
}
