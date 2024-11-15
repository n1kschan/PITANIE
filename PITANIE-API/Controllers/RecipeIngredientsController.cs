using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Domain.Models;
using Domain.Interfaces;
using BusinessLogic.Services;
using Питание.Contracts.RecipeIngredient;

namespace Питание.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RecipeIngredientController : ControllerBase
    {
        private IRecipeIngredientService _RecipeIngredientService;
        public RecipeIngredientController(IRecipeIngredientService RecipeIngredientService)
        {
            _RecipeIngredientService = RecipeIngredientService;
        }

        /// <summary>
        /// Отображение всех пользователей
        /// </summary>
        /// <param name="model">Пользователь</param>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _RecipeIngredientService.GetAll());
        }

        /// <summary>
        /// Отображение всех пользователей
        /// </summary>
        /// <param name="model">Пользователь</param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var result = await _RecipeIngredientService.GetById(id);
            var response = new RecipeIngredient()
            {
                RecipeIngredientId = result.RecipeIngredientId,
                RecipeId = result.RecipeId,
                FoodItemId = result.FoodItemId,
                Quantity = result.Quantity,
            };
            return Ok(result);
        }

        /// <summary>
        /// Создание нового пользователя
        /// </summary>
        /// <param name="model">Пользователь</param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> Add(CreateRecipeIngredientRequest request)
        {
            var userDto = new RecipeIngredient()
            {
                RecipeId = request.Recipeid,
                FoodItemId = request.Fooditemid,
                Quantity = request.Quantity,
            };
            await _RecipeIngredientService.Create(userDto);
            return Ok();
        }

        /// <summary>
        /// Изменяет данные у пользователя
        /// </summary>
        /// <param name="model">Пользователь</param>
        /// <returns></returns>
        [HttpPut]
        public async Task<IActionResult> Update(CreateRecipeIngredientRequest request)
        {
            var userDto = new RecipeIngredient()
            {
                RecipeId = request.Recipeid,
                FoodItemId = request.Fooditemid,
                Quantity = request.Quantity,
            };
            await _RecipeIngredientService.Create(userDto);
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
            var result = await _RecipeIngredientService.GetById(id);
            var response = new RecipeIngredient()
            {
                RecipeIngredientId = result.RecipeIngredientId,
                RecipeId = result.RecipeId,
                FoodItemId = result.FoodItemId,
                Quantity = result.Quantity,
            };
            await _RecipeIngredientService.Delete(id);
            return Ok();
        }
    }
}
