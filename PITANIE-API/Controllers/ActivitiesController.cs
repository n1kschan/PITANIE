using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Domain.Models;
using Domain.Interfaces;
using BusinessLogic.Services;
using Питание.Contracts.User;
using Питание.Contracts.Activity;

namespace Питание.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class ActivityController : ControllerBase
    {
        private IActivityService _activityService;
        public ActivityController(IActivityService activityService)
        {
            _activityService = activityService;
        }

        /// <summary>
        /// Отображение всех пользователей
        /// </summary>
        /// <param name="model">Пользователь</param>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _activityService.GetAll());
        }

        /// <summary>
        /// Отображение конкретного пользователя
        /// </summary>
        /// <param name="model">Пользователь</param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var result = await _activityService.GetById(id);
            var response = new GetActivityResponse()
            {
                Activityid = result.ActivityId,
                Userid = result.UserId,
                Activityname = result.ActivityName,
                Caloriesburned = result.CaloriesBurned,
                Duration = result.Duration,
            };
            return Ok(response);
        }

        /// <summary>
        /// Создание нового пользователя
        /// </summary>
        /// <param name="model">Пользователь</param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> Add(CreateActivityRequest request)
        {
            var userDto = new Activity()
            {
                UserId = request.Userid,
                ActivityName = request.Activityname,
                CaloriesBurned = request.Caloriesburned,
                Duration = request.Duration,
            };
            await _activityService.Create(userDto);
            return Ok();
        }

        /// <summary>
        /// Изменяет данные у пользователя
        /// </summary>
        /// <param name="model">Пользователь</param>
        /// <returns></returns>
        [HttpPut]
        public async Task<IActionResult> Update(UpdateActivityRequest request)
        {
            var userDto = new Activity()
            {
                UserId = request.Userid,
                ActivityName = request.Activityname,
                CaloriesBurned = request.Caloriesburned,
                Duration = request.Duration,
            };
            await _activityService.Update(userDto);
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
            var result = await _activityService.GetById(id);
            var response = new DeleteActivityResponse()
            {
                Activityid = result.ActivityId,
                Userid = result.UserId,
                Activityname = result.ActivityName,
                Caloriesburned = result.CaloriesBurned,
                Duration = result.Duration,
            };
            await _activityService.Delete(id);
            return Ok(response);
        }
    }
}
