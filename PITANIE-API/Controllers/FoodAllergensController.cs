using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Domain.Models;
using Domain.Interfaces;
using BusinessLogic.Services;
using Питание.Contracts.FavoriteRecipe;
using Питание.Contracts.FoodAllergen;

namespace Питание.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FoodAllergenController : ControllerBase
    {
        private IFoodAllergenService _FoodAllergenService;
        public FoodAllergenController(IFoodAllergenService FoodAllergenService)
        {
            _FoodAllergenService = FoodAllergenService;
        }

        /// <summary>
        /// Отображение всех пользователей
        /// </summary>
        /// <param name="model">Пользователь</param>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _FoodAllergenService.GetAll());
        }

        /// <summary>
        /// Отображение конкретного пользователя
        /// </summary>
        /// <param name="model">Пользователь</param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var result = await _FoodAllergenService.GetById(id);
            var response = new GetFoodAllergenResponse()
            {
                FoodAllergenid = result.FoodAllergenId,
                Fooditemid = result.FoodItemId,
                Allergenid = result.AllergenId,
            };
            return Ok(response);
        }

        /// <summary>
        /// Создание нового пользователя
        /// </summary>
        /// <param name="model">Пользователь</param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> Add(CreateFoodAllergenRequest request)
        {
            var userDto = new FoodAllergen()
            {
                FoodItemId = request.Fooditemid,
                AllergenId = request.Allergenid,
            };
            await _FoodAllergenService.Create(userDto);
            return Ok();
        }

        /// <summary>
        /// Изменяет данные у пользователя
        /// </summary>
        /// <param name="model">Пользователь</param>
        /// <returns></returns>
        [HttpPut]
        public async Task<IActionResult> Update(UpdateFoodAllergenRequest request)
        {
            var userDto = new FoodAllergen()
            {
                FoodItemId = request.Fooditemid,
                AllergenId = request.Allergenid,
            };
            await _FoodAllergenService.Update(userDto);
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
            var result = await _FoodAllergenService.GetById(id);
            var response = new DeleteFoodAllergenRequest()
            {
                FoodAllergenid = result.FoodAllergenId,
                Fooditemid = result.FoodItemId,
                Allergenid = result.AllergenId,
            };
            await _FoodAllergenService.Delete(id);
            return Ok(response);
        }
    }
}
