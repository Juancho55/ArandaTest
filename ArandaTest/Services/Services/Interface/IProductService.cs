namespace Services.Services.Interface
{
    public interface IProductService
    {
        public Task<string> SaveAsync(Models.Product.Product request);

        public Task<string> UpdateAsync(Models.Product.Product request);

        public Task<string> DeleteAsync(long produtId);

        public Task<List<Models.Product.Product>> GetAllAsync(Models.Product.PageAndOrder options);

        public Task<List<Models.Product.Product>> GetFiltersAsync(Models.Product.FilterProduct filter);
    }
}
