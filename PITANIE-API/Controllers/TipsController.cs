using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Domain.Models;
using Domain.Interfaces;
using BusinessLogic.Services;
using Питание.Contracts.Tip;

namespace Питание.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TipController : ControllerBase
    {
        private ITipService _TipService;
        public TipController(ITipService TipService)
        {
            _TipService = TipService;
        }

        /// <summary>
        /// Отображение всех пользователей
        /// </summary>
        /// <param name="model">Пользователь</param>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _TipService.GetAll());
        }

        /// <summary>
        /// Отображение всех пользователей
        /// </summary>
        /// <param name="model">Пользователь</param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var result = await _TipService.GetById(id);
            var response = new Tip()
            {
                TipId = result.TipId,
                UserId = result.UserId,
                TipText = result.TipText,
                Category = result.Category,
            };
            return Ok(response);
        }

        /// <summary>
        /// Создание нового пользователя
        /// </summary>
        /// <param name="model">Пользователь</param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> Add(CreateTipRequest request)
        {
            var userDto = new Tip()
            {
                UserId = request.UserID,
                TipText = request.TipText,
                Category = request.Category,
            };
            await _TipService.Create(userDto);
            return Ok();
        }

        /// <summary>
        /// Изменяет данные у пользователя
        /// </summary>
        /// <param name="model">Пользователь</param>
        /// <returns></returns>
        [HttpPut]
        public async Task<IActionResult> Update(CreateTipRequest request)
        {
            var userDto = new Tip()
            {
                UserId = request.UserID,
                TipText = request.TipText,
                Category = request.Category,
            };
            await _TipService.Create(userDto);
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
            var result = await _TipService.GetById(id);
            var response = new Tip()
            {
                TipId = result.TipId,
                UserId = result.UserId,
                TipText = result.TipText,
                Category = result.Category,
            };
            await _TipService.Delete(id);
            return Ok(response);
        }
    }
}
