using EntityFreamWorkBD.Data;
using Infra.Interface;
using Microsoft.EntityFrameworkCore;

namespace Infra.Category
{
    public class CategoryGet : ICategoryGet
    {
        private readonly ArandaTestDbContext _context;

        public CategoryGet(ArandaTestDbContext context)
        {
            _context = context;
        }

        public async Task<List<Models.Category.Category>> GetAll()
        {
            try
            {
                return await _context.Categories.Select(s => new Models.Category.Category
                {
                    Active = s.Active,
                    CreateDate = s.CreateDate,
                    Id = s.Id,
                    Name = s.Name
                }).ToListAsync();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
