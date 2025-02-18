namespace Infra.Interface
{
    public interface IProductUpdate
    {
        public Task<bool> Update(Models.Product.Product model);
    }
}
