using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Domain.Models;
using Domain.Interfaces;
using BusinessLogic.Services;
using Питание.Contracts.Profile;

namespace Питание.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProfileController : ControllerBase
    {
        private IProfileService _ProfileService;
        public ProfileController(IProfileService ProfileService)
        {
            _ProfileService = ProfileService;
        }

        /// <summary>
        /// Отображение всех пользователей
        /// </summary>
        /// <param name="model">Пользователь</param>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _ProfileService.GetAll());
        }

        /// <summary>
        /// Отображение всех пользователей
        /// </summary>
        /// <param name="model">Пользователь</param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var result = await _ProfileService.GetById(id);
            var response = new Profile()
            {
                ProfileId = result.ProfileId,
                UserId = result.UserId,
                FirstName = result.FirstName,
                LastName = result.LastName,
                DateOfBirth = result.DateOfBirth,
                Height = result.Height,
                Weight = result.Weight,
                Gender = result.Gender,
            };
            return Ok(response);
        }

        /// <summary>
        /// Создание нового пользователя
        /// </summary>
        /// <param name="model">Пользователь</param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> Add(CreateProfileRequest request)
        {
            var userDto = new Profile()
            {
                UserId = request.Userid,
                FirstName = request.Firstname,
                LastName = request.Lastname,
                DateOfBirth = request.Dateofbirth,
                Height = request.Height,
                Weight = request.Weight,
                Gender = request.Gender,
            };
            await _ProfileService.Create(userDto);
            return Ok();
        }

        /// <summary>
        /// Изменяет данные у пользователя
        /// </summary>
        /// <param name="model">Пользователь</param>
        /// <returns></returns>
        [HttpPut]
        public async Task<IActionResult> Update(CreateProfileRequest request)
        {
            var userDto = new Profile()
            {
                UserId = request.Userid,
                FirstName = request.Firstname,
                LastName = request.Lastname,
                DateOfBirth = request.Dateofbirth,
                Height = request.Height,
                Weight = request.Weight,
                Gender = request.Gender,
            };
            await _ProfileService.Create(userDto);
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
            var result = await _ProfileService.GetById(id);
            var response = new Profile()
            {
                ProfileId = result.ProfileId,
                UserId = result.UserId,
                FirstName = result.FirstName,
                LastName = result.LastName,
                DateOfBirth = result.DateOfBirth,
                Height = result.Height,
                Weight = result.Weight,
                Gender = result.Gender,
            };
            await _ProfileService.Delete(id);
            return Ok();
        }
    }
}
