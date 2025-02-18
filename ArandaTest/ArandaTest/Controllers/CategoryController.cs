using ArandaTest.Models.CategoryAPI;
using ArandaTest.Models.Mapper;
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
    public class CategoryController : BaseController
    {
        private readonly ICategoryServies _categoryServies;

        public CategoryController(ICategoryServies categoryServies)
        {
            _categoryServies = categoryServies;
        }

        [HttpPost]
        [AllowAnonymous]
        [Route("/api/category/")]
        public async Task<IActionResult> Save(CategoryRequestModel requestModel)
        {
            if (!ModelState.IsValid) return GetBadRequest();
            try
            {
                return new Result.CreateResult(await _categoryServies.SaveAsync(new CategoryMap().MapReq(requestModel)));
            }
            catch(Exception ex)
            {
                return GetErrorresult(ex);
            }
        }

        [HttpGet]
        [AllowAnonymous]
        [Route("/api/category/")]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                return new Result.CreateResult(new CategoryMap().MapRes(await _categoryServies.GetAsync()));
            }
            catch(Exception ex)
            {
                return GetErrorresult(ex);
            }
        }
    }
}
