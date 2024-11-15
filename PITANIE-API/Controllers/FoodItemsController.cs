using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Domain.Models;
using Domain.Interfaces;
using BusinessLogic.Services;
using Питание.Contracts.FoodItemCategory;
using Питание.Contracts.FoodItem;

namespace Питание.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FoodItemController : ControllerBase
    {
        private IFoodItemService _FoodItemService;
        public FoodItemController(IFoodItemService FoodItemService)
        {
            _FoodItemService = FoodItemService;
        }

        /// <summary>
        /// Отображение всех пользователей
        /// </summary>
        /// <param name="model">Пользователь</param>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _FoodItemService.GetAll());
        }

        /// <summary>
        /// Отображение всех пользователей
        /// </summary>
        /// <param name="model">Пользователь</param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var result = await _FoodItemService.GetById(id);
            var response = new FoodItem()
            {
                FoodItemId = result.FoodItemId,
                FoodName = result.FoodName,
                Calories = result.Calories,
                Protein = result.Protein,
                Carbohydrates = result.Carbohydrates,
                Fats = result.Fats,
            };
            return Ok(response);
        }

        /// <summary>
        /// Создание нового пользователя
        /// </summary>
        /// <param name="model">Пользователь</param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> Add(CreateFoodItemRequest request)
        {
            var userDto = new FoodItem()
            {
                FoodName = request.Foodname,
                Calories = request.Calories,
                Protein = request.Protein,
                Carbohydrates = request.Carbohydrates,
                Fats = request.Fats,
            };
            await _FoodItemService.Create(userDto);
            return Ok();
        }

        /// <summary>
        /// Изменяет данные у пользователя
        /// </summary>
        /// <param name="model">Пользователь</param>
        /// <returns></returns>
        [HttpPut]
        public async Task<IActionResult> Update(CreateFoodItemRequest request)
        {
            var userDto = new FoodItem()
            {
                FoodName = request.Foodname,
                Calories = request.Calories,
                Protein = request.Protein,
                Carbohydrates = request.Carbohydrates,
                Fats = request.Fats,
            };
            await _FoodItemService.Create(userDto);
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
            var result = await _FoodItemService.GetById(id);
            var response = new FoodItem()
            {
                FoodItemId = result.FoodItemId,
                FoodName = result.FoodName,
                Calories = result.Calories,
                Protein = result.Protein,
                Carbohydrates = result.Carbohydrates,
                Fats = result.Fats,
            };
            await _FoodItemService.Delete(id);
            return Ok();
        }
    }
}
