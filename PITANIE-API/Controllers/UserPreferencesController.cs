using Domain.Interfaces;
using Microsoft.AspNetCore.Http;
using Domain.Models;
using Microsoft.AspNetCore.Mvc;
using BusinessLogic.Services;
using Питание.Contracts.UserPreference;

namespace Питание.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserPreferenceController : ControllerBase
    {
        private IUserPreferenceService _UserPreferenceService;
        public UserPreferenceController(IUserPreferenceService UserPreferenceService)
        {
            _UserPreferenceService = UserPreferenceService;
        }

        /// <summary>
        /// Отображение всех пользователей
        /// </summary>
        /// <param name="model">Пользователь</param>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _UserPreferenceService.GetAll());
        }

        /// <summary>
        /// Отображение всех пользователей
        /// </summary>
        /// <param name="model">Пользователь</param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var result = await _UserPreferenceService.GetById(id);
            var response = new UserPreference()
            {
                UserPreferenceId = result.UserPreferenceId,
                UserId = result.UserId,
                PreferenceName = result.PreferenceName,
                PreferenceValue = result.PreferenceValue,
            };
            return Ok(response);
        }

        /// <summary>
        /// Создание нового пользователя
        /// </summary>
        /// <param name="model">Пользователь</param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> Add(CreateUserPreferenceRequest request)
        {
            var userDto = new UserPreference()
            {
                UserId = request.UserID,
                PreferenceName = request.PreferenceName,
                PreferenceValue = request.PreferenceValue,
            };
            await _UserPreferenceService.Create(userDto);
            return Ok();
        }

        /// <summary>
        /// Изменяет данные у пользователя
        /// </summary>
        /// <param name="model">Пользователь</param>
        /// <returns></returns>
        [HttpPut]
        public async Task<IActionResult> Update(CreateUserPreferenceRequest request)
        {
            var userDto = new UserPreference()
            {
                UserId = request.UserID,
                PreferenceName = request.PreferenceName,
                PreferenceValue = request.PreferenceValue,
            };
            await _UserPreferenceService.Create(userDto);
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
            var result = await _UserPreferenceService.GetById(id);
            var response = new UserPreference()
            {
                UserPreferenceId = result.UserPreferenceId,
                UserId = result.UserId,
                PreferenceName = result.PreferenceName,
                PreferenceValue = result.PreferenceValue,
            };
            await _UserPreferenceService.Delete(id);
            return Ok(response);
        }
    }
}
