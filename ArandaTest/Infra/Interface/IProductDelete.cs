namespace Infra.Interface
{
    public interface IProductDelete
    {
        public Task<bool> Delete(long id);
    }
}
