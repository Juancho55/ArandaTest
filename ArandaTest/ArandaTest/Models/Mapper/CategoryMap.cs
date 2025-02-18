using ArandaTest.Models.CategoryAPI;
using Models.Category;

namespace ArandaTest.Models.Mapper
{
    public class CategoryMap
    {
        public Category MapReq(CategoryRequestModel model)
        {
            return new Category()
            {
                Id = model.Id,
                Name = model.Name
            };
        }

        public List<CategoryResponseModel> MapRes(List<Category> response)
        {
            return response.Select(s => new CategoryResponseModel
            {
                Name = s.Name,
                Active = s.Active,
                CreateDate = s.CreateDate,
                Id = s.Id
            }).ToList();
        }
    }
}
