using EntityFreamWorkBD.Data;
using Infra.Interface;

namespace Infra.Category
{
    public class CategorySave : ICategorySave
    {
        private readonly ArandaTestDbContext _context;

        public CategorySave(ArandaTestDbContext context)
        {
            _context = context;
        }

        public async Task<bool> Save(Models.Category.Category model)
        {
            try
            {
                EntityFreamWorkBD.Models.Category category = new EntityFreamWorkBD.Models.Category()
                {
                    Id = model.Id,
                    Name = model.Name,
                    Active = Constant.Ative,
                    CreateDate = DateTime.Now
                };
                await _context.Categories.AddAsync(category);
                return await _context.SaveChangesAsync() > 0;
            }
            catch(Exception ex)
            {
                throw (new Exception(ex.Message));
            }
        }
    }
}
