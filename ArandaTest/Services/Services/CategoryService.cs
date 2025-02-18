using Infra.Interface;
using Services.Services.Interface;

namespace Services.Services
{
    public class CategoryService : ICategoryServies
    {
        private readonly ICategorySave _categorySave;
        private readonly ICategoryGet _categoryGet;

        public CategoryService(ICategorySave categorySave, ICategoryGet categoryGet)
        {
            _categorySave = categorySave;
            _categoryGet = categoryGet;
        }

        public async Task<bool> SaveAsync(Models.Category.Category request)
        {
            return await _categorySave.Save(request);
        }

        public async Task<List<Models.Category.Category>> GetAsync()
        {
            return await _categoryGet.GetAll();
        }
    }
}
