using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Domain.Models;
using Domain.Interfaces;
using BusinessLogic.Services;
using Питание.Contracts.Meal;

namespace Питание.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MealController : ControllerBase
    {
        private IMealService _MealService;
        public MealController(IMealService MealService)
        {
            _MealService = MealService;
        }

        /// <summary>
        /// Отображение всех пользователей
        /// </summary>
        /// <param name="model">Пользователь</param>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _MealService.GetAll());
        }

        /// <summary>
        /// Отображение всех пользователей
        /// </summary>
        /// <param name="model">Пользователь</param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var result = await _MealService.GetById(id);
            var response = new Meal()
            {
                MealId = result.MealId,
                MealPlanId = result.MealPlanId,
                MealType = result.MealType,
                MealDate = result.MealDate,
            };
            return Ok(response);
        }


        /// <summary>
        /// Создание нового пользователя
        /// </summary>
        /// <param name="model">Пользователь</param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> Add(CreateMealRequest request)
        {
            var userDto = new Meal()
            {
                MealPlanId = request.Mealplanid,
                MealType = request.Mealtype,
                MealDate = request.Mealdate,
            };
            await _MealService.Create(userDto);
            return Ok();
        }

        /// <summary>
        /// Изменяет данные у пользователя
        /// </summary>
        /// <param name="model">Пользователь</param>
        /// <returns></returns>
        [HttpPut]
        public async Task<IActionResult> Update(CreateMealRequest request)
        {
            var userDto = new Meal()
            {
                MealPlanId = request.Mealplanid,
                MealType = request.Mealtype,
                MealDate = request.Mealdate,
            };
            await _MealService.Update(userDto);
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
            var result = await _MealService.GetById(id);
            var response = new Meal()
            {
                MealId = result.MealId,
                MealPlanId = result.MealPlanId,
                MealType = result.MealType,
                MealDate = result.MealDate,
            };
            await _MealService.Delete(id);
            return Ok(response);
        }
    }
}
