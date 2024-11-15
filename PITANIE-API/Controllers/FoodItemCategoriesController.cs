using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Domain.Models;
using Domain.Interfaces;
using BusinessLogic.Services;
using Питание.Contracts.FoodCategory;
using Питание.Contracts.FoodItemCategory;

namespace Питание.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FoodItemCategoryController : ControllerBase
    {
        private IFoodItemCategoryService _FoodItemCategoryService;
        public FoodItemCategoryController(IFoodItemCategoryService FoodItemCategoryService)
        {
            _FoodItemCategoryService = FoodItemCategoryService;
        }

        /// <summary>
        /// Отображение всех пользователей
        /// </summary>
        /// <param name="model">Пользователь</param>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _FoodItemCategoryService.GetAll());
        }

        /// <summary>
        /// Отображение всех пользователей
        /// </summary>
        /// <param name="model">Пользователь</param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var result = await _FoodItemCategoryService.GetById(id);
            var response = new GetFoodItemCategoryResponse()
            {
                Fooditemcategoryid = result.FoodItemCategoryId,
                Fooditemid = result.FoodItemId,
                Foodcategoryid = result.FoodCategoryId,
            };
            return Ok(response);
        }

        /// <summary>
        /// Создание нового пользователя
        /// </summary>
        /// <param name="model">Пользователь</param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> Add(CreateFoodItemCategoryRequest request)
        {
            var userDto = new FoodItemCategory()
            {
                FoodItemId = request.Fooditemid,
                FoodItemCategoryId = request.FoodCategoryid
            };
            await _FoodItemCategoryService.Create(userDto);
            return Ok();
        }

        /// <summary>
        /// Изменяет данные у пользователя
        /// </summary>
        /// <param name="model">Пользователь</param>
        /// <returns></returns>
        [HttpPut]
        public async Task<IActionResult> Update(CreateFoodItemCategoryRequest request)
        {
            var userDto = new FoodItemCategory()
            {
                FoodItemId = request.Fooditemid,
                FoodItemCategoryId = request.FoodCategoryid
            };
            await _FoodItemCategoryService.Create(userDto);
            return Ok();
        }

        /// <summary>
        /// Удаляет выбранного пользователя
        /// </summary>
        /// <param name="model">Пользователь</param>
        /// <returns></returns>
        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _FoodItemCategoryService.GetById(id);
            var response = new GetFoodItemCategoryResponse()
            {
                Fooditemcategoryid = result.FoodItemCategoryId,
                Fooditemid = result.FoodItemId,
                Foodcategoryid = result.FoodCategoryId,
            };
            await _FoodItemCategoryService.Delete(id);
            return Ok(response);
        }
    }
}
