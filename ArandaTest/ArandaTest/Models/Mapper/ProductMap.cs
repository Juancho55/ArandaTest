using ArandaTest.Models.ProductAPI;
using Models.Product;
using System.Xml;

namespace ArandaTest.Models.Mapper
{
    public class ProductMap
    {
        public Product MapReq(ProductRequestModel model, int productId = 0)
        {
            return new Product()
            {
                Active = model.Active,                
                Id = productId,
                IdCategory = model.IdCategory,
                Name = model.Name,
                ShortDescription = model.ShortDescription,
                ImageP = model.ImageP
            };
        }

        public FilterProduct MapReqFilter(FilterRequestModel model)
        {
            return new FilterProduct()
            {
                FilterOption = model.FilterOption,
                Name = model.Name,
                Category = model.Category,
                ShortDescription = model.ShortDescription
            };
        }

        public PageAndOrder MapReqPage(PageAndOrderRequestModel model)
        {
            return new PageAndOrder()
            {
                PageCurrent = model.PageCurrent,
                PageSize = model.PageSize,
                OrderByName = model.OrderByName,
                OrderByCategory = model.OrderByCategory
            };
        }

        public List<ProductResposeModel> MapResp(List<Product> response)
        {
            return response.Select(s => new ProductResposeModel
            {
                Active = s.Active,
                CreateDate = s.CreateDate,
                Id = s.Id,
                IdCategory = s.IdCategory,
                ImageP = s.ImageP,
                Name = s.Name,
                ShortDescription = s.ShortDescription
            }).ToList();
        }
    }
}
