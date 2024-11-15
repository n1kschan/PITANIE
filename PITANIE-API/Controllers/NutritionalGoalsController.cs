using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Domain.Models;
using Domain.Interfaces;
using BusinessLogic.Services;
using Питание.Contracts.NutritionalGoal;

namespace Питание.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NutritionalGoalController : ControllerBase
    {
        private INutritionalGoalService _NutritionalGoalService;
        public NutritionalGoalController(INutritionalGoalService NutritionalGoalService)
        {
            _NutritionalGoalService = NutritionalGoalService;
        }

        /// <summary>
        /// Отображение всех пользователей
        /// </summary>
        /// <param name="model">Пользователь</param>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _NutritionalGoalService.GetAll());
        }

        /// <summary>
        /// Отображение всех пользователей
        /// </summary>
        /// <param name="model">Пользователь</param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var result = await _NutritionalGoalService.GetById(id);
            var response = new NutritionalGoal()
            {
                GoalId = result.GoalId,
                UserId = result.UserId,
                DailyCaloricIntake = result.DailyCaloricIntake,
                ProteinGoal = result.ProteinGoal,
                CarbohydrateGoal = result.CarbohydrateGoal,
                FatGoal = result.FatGoal,
            };
            return Ok(result);
        }

        /// <summary>
        /// Создание нового пользователя
        /// </summary>
        /// <param name="model">Пользователь</param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> Add(CreateNutritionalGoalRequest request)
        {
            var userDto = new NutritionalGoal()
            {
                UserId = request.Userid,
                DailyCaloricIntake = request.Dailycaloricintake,
                ProteinGoal = request.Dailycaloricintake,
                CarbohydrateGoal = request.Carbohydrategoal,
                FatGoal = request.Fatgoal,
            };
            await _NutritionalGoalService.Create(userDto);
            return Ok();
        }

        /// <summary>
        /// Изменяет данные у пользователя
        /// </summary>
        /// <param name="model">Пользователь</param>
        /// <returns></returns>
        [HttpPut]
        public async Task<IActionResult> Update(CreateNutritionalGoalRequest request)
        {
            var userDto = new NutritionalGoal()
            {
                UserId = request.Userid,
                DailyCaloricIntake = request.Dailycaloricintake,
                ProteinGoal = request.Dailycaloricintake,
                CarbohydrateGoal = request.Carbohydrategoal,
                FatGoal = request.Fatgoal,
            };
            await _NutritionalGoalService.Update(userDto);
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
            var result = await _NutritionalGoalService.GetById(id);
            var response = new NutritionalGoal()
            {
                GoalId = result.GoalId,
                UserId = result.UserId,
                DailyCaloricIntake = result.DailyCaloricIntake,
                ProteinGoal = result.ProteinGoal,
                CarbohydrateGoal = result.CarbohydrateGoal,
                FatGoal = result.FatGoal,
            };
            await _NutritionalGoalService.Delete(id);
            return Ok();
        }
    }
}
