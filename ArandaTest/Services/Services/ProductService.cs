using Infra.Interface;
using Services.Services.Interface;

namespace Services.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductSave _produtSave;
        private readonly IProductUpdate _productUpdate;
        private readonly IProductDelete _productDelete;
        private readonly IProductGet _productGet;

        public ProductService(IProductSave produtSave, IProductUpdate productUpdate, IProductDelete productDelete, IProductGet productGet)
        {
            _produtSave = produtSave;
            _productUpdate = productUpdate;
            _productDelete = productDelete;
            _productGet = productGet;
        }

        public async Task<string> SaveAsync(Models.Product.Product request)
        {
            return (await _produtSave.Save(request) ? string.Format(Constants.OK, Constants.SAVE) : string.Format(Constants.ERROR, Constants.SAVE));
        }

        public async Task<string> UpdateAsync(Models.Product.Product request)
        {
            return (await _productUpdate.Update(request) ? string.Format(Constants.OK, Constants.UPDATE) : string.Format(Constants.ERROR, Constants.UPDATE));
        }

        public async Task<string> DeleteAsync(long produtId)
        {
            return (await _productDelete.Delete(produtId) ? string.Format(Constants.OK, Constants.DELETE) : string.Format(Constants.ERROR, Constants.DELETE));
        }

        public async Task<List<Models.Product.Product>> GetAllAsync(Models.Product.PageAndOrder options)
        {
            return await _productGet.GetAll(options);
        }

        public async Task<List<Models.Product.Product>> GetFiltersAsync(Models.Product.FilterProduct filter)
        {
            return await _productGet.GetByFilter(filter);
        }
    }
}
