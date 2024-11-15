using BusinessLogic.Services;
using Domain.Interfaces;
using Domain.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Питание.Contracts.Allergen;
using Питание.Contracts.FavoriteRecipe;

namespace Питание.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FavoriteRecipeController : ControllerBase
    {
        private IFavoriteRecipeService _FavoriteRecipeService;
        public FavoriteRecipeController(IFavoriteRecipeService FavoriteRecipeService)
        {
            _FavoriteRecipeService = FavoriteRecipeService;
        }

        /// <summary>
        /// Отображение всех пользователей
        /// </summary>
        /// <param name="model">Пользователь</param>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _FavoriteRecipeService.GetAll());
        }

        /// <summary>
        /// Отображение конкретного пользователя
        /// </summary>
        /// <param name="model">Пользователь</param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var result = await _FavoriteRecipeService.GetById(id);
            var response = new GetFavoriteRecipeResponse()
            {
                FavoriteRecipeid = result.FavoriteRecipeId,
                Userid = result.UserId,
                Recipeid = result.FavoriteRecipeId,
            };
            return Ok(response);
        }


        /// <summary>
        /// Создание нового пользователя
        /// </summary>
        /// <param name="model">Пользователь</param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> Add(CreateFavoriteRecipeRequest request)
        {
            var userDto = new FavoriteRecipe()
            {
                UserId = request.Userid,
                RecipeId = request.Recipeid,
            };
            await _FavoriteRecipeService.Create(userDto);
            return Ok();
        }

        /// <summary>
        /// Изменяет данные у пользователя
        /// </summary>
        /// <param name="model">Пользователь</param>
        /// <returns></returns>
        [HttpPut]
        public async Task<IActionResult> Update(UpdateFavoriteRecipeRequest request)
        {
            var userDto = new FavoriteRecipe()
            {
                UserId = request.Userid,
                RecipeId = request.Recipeid,
            };
            await _FavoriteRecipeService.Update(userDto);
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
            var result = await _FavoriteRecipeService.GetById(id);
            var response = new DeleteFavoriteRecipeRequest()
            {
                FavoriteRecipeid = result.FavoriteRecipeId,
                Userid = result.UserId,
                Recipeid = result.RecipeId,
            };
            await _FavoriteRecipeService.Delete(id);
            return Ok(response);
        }
    }
}
