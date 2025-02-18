using ArandaTest.Models.Mapper;
using ArandaTest.Models.ProductAPI;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Services.Services.Interface;
using System.Net.Mime;

namespace ArandaTest.Controllers
{
    [ApiController]
    [Produces(MediaTypeNames.Application.Json)]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public class ProductController : BaseController
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpPost]
        [AllowAnonymous]
        [Route("/api/product/")]
        public async Task<IActionResult> Save([FromBody] ProductRequestModel requestModel)
        {
            if (!ModelState.IsValid) return GetBadRequest();
            try
            {
                return new Result.CreateResult(await _productService.SaveAsync(new ProductMap().MapReq(requestModel)));
            }
            catch(Exception ex)
            {
                return GetErrorresult(ex);
            }
        }

        [HttpPut]
        [AllowAnonymous]
        [Route("/api/product/")]
        public async Task<IActionResult> Update(int id, [FromBody] ProductRequestModel requestModel)
        {
            if (!ModelState.IsValid) return GetBadRequest();
            try
            {
                return new Result.CreateResult(await _productService.UpdateAsync(new ProductMap().MapReq(requestModel, id)));
            }
            catch (Exception ex)
            {
                return GetErrorresult(ex);
            }
        }

        [HttpDelete]
        [AllowAnonymous]
        [Route("/api/product/")]
        public async Task<IActionResult> Delete(long id)
        {
            if (!ModelState.IsValid) return GetBadRequest();
            try
            {
                return new Result.CreateResult(await _productService.DeleteAsync(id));
            }
            catch (Exception ex)
            {
                return GetErrorresult(ex);
            }
        }

        [HttpGet]
        [AllowAnonymous]
        [Route("/api/product/")]
        public async Task<IActionResult> GetAll([FromBody] PageAndOrderRequestModel optionsModel)
        {
            if (!ModelState.IsValid) return GetBadRequest();
            try
            {
                return new Result.CreateResult(new ProductMap().MapResp(await _productService.GetAllAsync(new ProductMap().MapReqPage(optionsModel))));
            }
            catch(Exception ex)
            {
                return GetErrorresult(ex);
            }
        }

        [HttpGet]
        [AllowAnonymous]
        [Route("/api/product/filter/")]
        public async Task<IActionResult> GetByFilter([FromBody] FilterRequestModel filterModel)
        {
            if (!ModelState.IsValid) return GetBadRequest();
            try
            {
                return new Result.CreateResult(new ProductMap().MapResp(await _productService.GetFiltersAsync(new ProductMap().MapReqFilter(filterModel))));
            }
            catch(Exception ex)
            {
                return GetErrorresult(ex);
            }
        }
    }
}
