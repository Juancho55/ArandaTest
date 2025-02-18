namespace Infra.Interface
{
    public interface IProductGet
    {
        public Task<List<Models.Product.Product>> GetAll(Models.Product.PageAndOrder options);
        public Task<List<Models.Product.Product>> GetByFilter(Models.Product.FilterProduct model);
    }
}
