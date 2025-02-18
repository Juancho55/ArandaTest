namespace Infra.Interface
{
    public interface IProductSave
    {
        public Task<bool> Save(Models.Product.Product model);
    }
}
