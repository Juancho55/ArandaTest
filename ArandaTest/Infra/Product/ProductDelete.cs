using EntityFreamWorkBD.Data;
using Infra.Interface;

namespace Infra.Product
{
    public class ProductDelete : IProductDelete
    {
        private readonly ArandaTestDbContext _context;

        public ProductDelete(ArandaTestDbContext context)
        {
            _context = context;
        }

        public async Task<bool> Delete(long id)
        {
            try
            {
                var produt = await _context.Products.FindAsync(id);

                if (produt is null)
                    return false;

                _context.Products.Remove(produt);

                return await _context.SaveChangesAsync() > 0;
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
