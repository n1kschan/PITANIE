using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Domain.Models;
using Domain.Interfaces;
using BusinessLogic.Services;
using Питание.Contracts.MealFoodItem;

namespace Питание.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MealFoodItemController : ControllerBase
    {
        private IMealFoodItemService _MealFoodItemService;
        public MealFoodItemController(IMealFoodItemService MealFoodItemService)
        {
            _MealFoodItemService = MealFoodItemService;
        }

        /// <summary>
        /// Отображение всех пользователей
        /// </summary>
        /// <param name="model">Пользователь</param>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _MealFoodItemService.GetAll());
        }

        /// <summary>
        /// Отображение всех пользователей
        /// </summary>
        /// <param name="model">Пользователь</param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var result = await _MealFoodItemService.GetById(id);
            var response = new MealFoodItem()
            {
                MealFoodItemId = result.MealFoodItemId,
                MealId = result.MealId,
                FoodItemId = result.FoodItemId,
                ServingSize = result.ServingSize,
            };
            return Ok(response);
        }

        /// <summary>
        /// Создание нового пользователя
        /// </summary>
        /// <param name="model">Пользователь</param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> Add(CreateMealFoodItemRequest request)
        {
            var userDto = new MealFoodItem()
            {
                MealId = request.Mealid,
                FoodItemId = request.Fooditemid,
                ServingSize = request.Servingsize,
            };
            await _MealFoodItemService.Create(userDto);
            return Ok();
        }

        /// <summary>
        /// Изменяет данные у пользователя
        /// </summary>
        /// <param name="model">Пользователь</param>
        /// <returns></returns>
        [HttpPut]
        public async Task<IActionResult> Update(CreateMealFoodItemRequest request)
        {
            var userDto = new MealFoodItem()
            {
                MealId = request.Mealid,
                FoodItemId = request.Fooditemid,
                ServingSize = request.Servingsize,
            };
            await _MealFoodItemService.Create(userDto);
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
            var result = await _MealFoodItemService.GetById(id);
            var response = new MealFoodItem()
            {
                MealFoodItemId = result.MealFoodItemId,
                MealId = result.MealId,
                FoodItemId = result.FoodItemId,
                ServingSize = result.ServingSize,
            };
            await _MealFoodItemService.Delete(id);
            return Ok(response);
        }
    }
}
