using EntityFreamWorkBD.Data;
using Infra.Interface;

namespace Infra.Product
{
    public class ProductSave : IProductSave
    {
        private readonly ArandaTestDbContext _context;

        public ProductSave(ArandaTestDbContext context)
        {
            _context = context;
        }

        public async Task<bool> Save(Models.Product.Product model)
        {
            try
            {
                EntityFreamWorkBD.Models.Product product = new EntityFreamWorkBD.Models.Product()
                {
                    Active = Constant.Ative,
                    CreateDate = DateTime.Now,
                    IdCategory = model.IdCategory,
                    ImageP = model.ImageP,
                    Name = model.Name,
                    ShortDescription = model.ShortDescription
                };
                await _context.Products.AddAsync(product);
                return await _context.SaveChangesAsync() > 0;
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
