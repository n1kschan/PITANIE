using Domain.Interfaces;
using Microsoft.AspNetCore.Http;
using Domain.Models;
using Microsoft.AspNetCore.Mvc;
using Питание.Contracts.User;

namespace Питание.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private IUserService _userService;
        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        /// <summary>
        /// Отображение всех пользователей
        /// </summary>
        /// <param name="model">Пользователь</param>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _userService.GetAll());
        }

        /// <summary>
        /// Отображение конкретного пользователя
        /// </summary>
        /// <param name="model">Пользователь</param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var result = await _userService.GetById(id);
            var response = new GetUserResponse()
            {
                Userid = result.UserId,
                Username = result.Username,
                Paswordhash = result.PasswordHash,
                Email = result.Email,
                Createdat = result.CreatedAt,
            };
            return Ok(response);
        }

        /// <summary>
        /// Создание нового пользователя
        /// </summary>
        /// <param name="model">Пользователь</param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> Add(CreateUserRequest request)
        {
            var userDto = new User()
            {
                Username = request.Username,
                PasswordHash = request.Paswordhash,
                Email = request.Email,
                CreatedAt = request.Createdat,
            };
            await _userService.Create(userDto);
            return Ok();
        }

        /// <summary>
        /// Изменяет данные у пользователя
        /// </summary>
        /// <param name="model">Пользователь</param>
        /// <returns></returns>
        [HttpPut]
        public async Task<IActionResult> Update(UpdateUserRequest request)
        {
            var userDto = new User()
            {
                Username = request.Username,
                PasswordHash = request.Paswordhash,
                Email = request.Email,
                CreatedAt = request.Createdat,
            };
            await _userService.Update(userDto);
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
            var result = await _userService.GetById(id);
            var response = new DeleteUserResponse()
            {
                Userid = result.UserId,
                Username = result.Username,
                Paswordhash = result.PasswordHash,
                Email = result.Email,
                Createdat = result.CreatedAt,
            };
            await _userService.Delete(id);
            return Ok(response);
        }
    }
}
