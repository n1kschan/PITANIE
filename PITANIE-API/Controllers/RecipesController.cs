using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Domain.Models;
using Domain.Interfaces;
using Питание.Contracts.Recipe;

namespace Питание.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RecipeController : ControllerBase
    {
        private IRecipeService _RecipeService;
        public RecipeController(IRecipeService RecipeService)
        {
            _RecipeService = RecipeService;
        }

        /// <summary>
        /// Отображение всех пользователей
        /// </summary>
        /// <param name="model">Пользователь</param>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _RecipeService.GetAll());
        }

        /// <summary>
        /// Отображение всех пользователей
        /// </summary>
        /// <param name="model">Пользователь</param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var result = await _RecipeService.GetById(id);
            var response = new Recipe()
            {
                RecipeId = result.RecipeId,
                RecipeName = result.RecipeName,
                PreparationTime = result.PreparationTime,
                CookingTime = result.CookingTime,
                Instructions = result.Instructions,
            };
            return Ok(response);
        }

        /// <summary>
        /// Создание нового пользователя
        /// </summary>
        /// <param name="model">Пользователь</param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> Add(CreateRecipeRequest request)
        {
            var userDto = new Recipe()
            {
                RecipeName = request.Recipename,
                PreparationTime = request.Preparationtime,
                CookingTime = request.Cookingtime,
                Instructions = request.Instructions,
            };
            await _RecipeService.Create(userDto);
            return Ok();
        }

        /// <summary>
        /// Изменяет данные у пользователя
        /// </summary>
        /// <param name="model">Пользователь</param>
        /// <returns></returns>
        [HttpPut]
        public async Task<IActionResult> Update(CreateRecipeRequest request)
        {
            var userDto = new Recipe()
            {
                RecipeName = request.Recipename,
                PreparationTime = request.Preparationtime,
                CookingTime = request.Cookingtime,
                Instructions = request.Instructions,
            };
            await _RecipeService.Update(userDto);
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
            var result = await _RecipeService.GetById(id);
            var response = new Recipe()
            {
                RecipeId = result.RecipeId,
                RecipeName = result.RecipeName,
                PreparationTime = result.PreparationTime,
                CookingTime = result.CookingTime,
                Instructions = result.Instructions,
            };
            await _RecipeService.Delete(id);
            return Ok(response);
        }
    }
}
