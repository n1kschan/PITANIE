using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Domain.Models;
using Domain.Interfaces;
using BusinessLogic.Services.BusinessLogic.Services;
using Питание.Contracts.MealPlan;

namespace Питание.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MealPlanController : ControllerBase
    {
        private IMealPlanService _MealPlanService;
        public MealPlanController(IMealPlanService MealPlanService)
        {
            _MealPlanService = MealPlanService;
        }

        /// <summary>
        /// Отображение всех пользователей
        /// </summary>
        /// <param name="model">Пользователь</param>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _MealPlanService.GetAll());
        }

        /// <summary>
        /// Отображение всех пользователей
        /// </summary>
        /// <param name="model">Пользователь</param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var result = await _MealPlanService.GetById(id);
            var response = new MealPlan()
            {
                MealPlanId = result.MealPlanId,
                UserId = result.UserId,
                PlanName = result.PlanName,
                StartDate = result.StartDate,
                EndDate = result.EndDate,
            };
            return Ok(await _MealPlanService.GetById(id));
        }

        /// <summary>
        /// Создание нового пользователя
        /// </summary>
        /// <param name="model">Пользователь</param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> Add(CreateMealPlanRequest request)
        {
            var userDto = new MealPlan()
            {
                UserId = request.Userid,
                PlanName = request.Planname,
                StartDate = request.Startdate,
                EndDate = request.Enddate,
            };
            await _MealPlanService.Create(userDto);
            return Ok();
        }

        /// <summary>
        /// Изменяет данные у пользователя
        /// </summary>
        /// <param name="model">Пользователь</param>
        /// <returns></returns>
        [HttpPut]
        public async Task<IActionResult> Update(CreateMealPlanRequest request)
        {
            var userDto = new MealPlan()
            {
                UserId = request.Userid,
                PlanName = request.Planname,
                StartDate = request.Startdate,
                EndDate = request.Enddate,
            };
            await _MealPlanService.Create(userDto);
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
            var result = await _MealPlanService.GetById(id);
            var response = new MealPlan()
            {
                MealPlanId = result.MealPlanId,
                UserId = result.UserId,
                PlanName = result.PlanName,
                StartDate = result.StartDate,
                EndDate = result.EndDate,
            };
            await _MealPlanService.Delete(id);
            return Ok();
        }
    }
}
