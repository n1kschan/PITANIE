using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Domain.Models;
using Domain.Interfaces;
using BusinessLogic.Services;
using Питание.Contracts.FoodAllergen;
using Питание.Contracts.FoodCategory;

namespace Питание.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FoodCategoryController : ControllerBase
    {
        private IFoodCategoryService _FoodCategoryService;
        public FoodCategoryController(IFoodCategoryService FoodCategoryService)
        {
            _FoodCategoryService = FoodCategoryService;
        }

        /// <summary>
        /// Отображение всех пользователей
        /// </summary>
        /// <param name="model">Пользователь</param>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _FoodCategoryService.GetAll());
        }

        /// <summary>
        /// Отображение конкретного пользователя
        /// </summary>
        /// <param name="model">Пользователь</param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var result = await _FoodCategoryService.GetById(id);
            var response = new GetFoodCategoryResponse()
            {
                FoodCategoryid = result.FoodCategoryId,
                Categoryname = result.CategoryName,
            };
            return Ok(response);
        }

        /// <summary>
        /// Создание нового пользователя
        /// </summary>
        /// <param name="model">Пользователь</param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> Add(CreateFoodCategoryRequest request)
        {
            var userDto = new FoodCategory()
            {
                CategoryName = request.Categoryname,
            };
            await _FoodCategoryService.Create(userDto);
            return Ok();
        }

        /// <summary>
        /// Изменяет данные у пользователя
        /// </summary>
        /// <param name="model">Пользователь</param>
        /// <returns></returns>
        [HttpPut]
        public async Task<IActionResult> Update(UpdateFoodCategoryRequest request)
        {
            var userDto = new FoodCategory()
            {
                CategoryName = request.Categoryname,
            };
            await _FoodCategoryService.Update(userDto);
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
            var result = await _FoodCategoryService.GetById(id);
            var response = new DeleteFoodCategoryRequest()
            {
                FoodCategoryid = result.FoodCategoryId,
                Categoryname = result.CategoryName,
            };
            await _FoodCategoryService.Delete(id);
            return Ok(response);
        }
    }
}
