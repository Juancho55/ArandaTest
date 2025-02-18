using EntityFreamWorkBD.Data;
using Infra.Interface;
using Microsoft.EntityFrameworkCore;

namespace Infra.Product
{
    public class ProductGet : IProductGet
    {
        private readonly ArandaTestDbContext _context;

        public ProductGet(ArandaTestDbContext context)
        {
            _context = context;
        }

        public async Task<List<Models.Product.Product>> GetAll(Models.Product.PageAndOrder options)
        {
            try
            {
                int skip = options.PageCurrent - 1 * options.PageSize;

                var query = _context.Products.AsQueryable();

                if (options.OrderByName != null && options.OrderByCategory != null)
                    query = options.OrderByName.Value && options.OrderByCategory.Value
                        ? query.OrderBy(o => o.Name).OrderBy(o => o.IdCategory)
                        : !options.OrderByName.Value && options.OrderByCategory.Value
                        ? query.OrderByDescending(o => o.Name).OrderBy(o => o.IdCategory)
                        : options.OrderByName.Value && !options.OrderByCategory.Value
                        ? query.OrderBy(o => o.Name).OrderByDescending(o => o.IdCategory)
                        : query.OrderByDescending(o => o.Name).OrderByDescending(o => o.IdCategory);
                else if (options.OrderByName != null && options.OrderByCategory == null)
                    query = options.OrderByName.Value ? query.OrderBy(o => o.Name) : query.OrderByDescending(o => o.Name);
                else if (options.OrderByName == null && options.OrderByCategory != null)
                    query = options.OrderByCategory.Value ? query.OrderBy(o => o.IdCategory) : query.OrderByDescending(o => o.IdCategory);

                return await query
                    .Skip(skip)
                    .Take(options.PageSize)
                    .Select(s => new Models.Product.Product
                    {
                        Active = s.Active,
                        CreateDate = s.CreateDate,
                        Id = s.Id,
                        IdCategory = s.IdCategory,
                        ImageP = s.ImageP,
                        Name = s.Name,
                        ShortDescription = s.ShortDescription,
                    }).ToListAsync();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<List<Models.Product.Product>> GetByFilter(Models.Product.FilterProduct model)
        {
            try
            {
                var query = _context.Products.AsQueryable();
                switch (model.FilterOption)
                {
                    case Constant.Name:
                        query = query.Where(w => w.Name.Contains(model.Name));
                        break;
                    case Constant.Category:
                        query = query.Where(w => w.IdCategoryNavigation.Name.Contains(model.Category));
                        break;
                    case Constant.ShortDescription:
                        query = query.Where(w => w.ShortDescription.Contains(model.ShortDescription));
                        break;
                }

                return await query.Select(s => new Models.Product.Product
                {
                    Active = s.Active,
                    CreateDate = s.CreateDate,
                    Id = s.Id,
                    IdCategory = s.IdCategory,
                    ImageP = s.ImageP,
                    Name = s.Name,
                    ShortDescription = s.ShortDescription,
                }).ToListAsync();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

    }
}
