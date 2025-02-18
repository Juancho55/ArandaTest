using EntityFreamWorkBD.Data;
using Infra.Interface;
using Microsoft.EntityFrameworkCore;

namespace Infra.Product
{
    public class ProductUpdate : IProductUpdate
    {
        private readonly ArandaTestDbContext _context;

        public ProductUpdate(ArandaTestDbContext context)
        {
            _context = context;
        }

        public async Task<bool> Update(Models.Product.Product model)
        {
            try
            {
                var productBefore = await _context.Products.FindAsync(model.Id);
                if (productBefore is null)
                    return false;

                productBefore.ShortDescription = model?.ShortDescription ?? productBefore.ShortDescription;
                productBefore.Active = model?.Active ?? productBefore.Active;
                productBefore.Name = model?.Name ?? productBefore.Name;
                productBefore.IdCategory = model?.IdCategory ?? productBefore.IdCategory;

                return await _context.SaveChangesAsync() > 0;
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
