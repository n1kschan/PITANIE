using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Domain.Models;
using Domain.Interfaces;
using BusinessLogic.Services;
using Питание.Contracts.Record;

namespace Питание.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RecordController : ControllerBase
    {
        private IRecordService _RecordService;
        public RecordController(IRecordService RecordService)
        {
            _RecordService = RecordService;
        }

        /// <summary>
        /// Отображение всех пользователей
        /// </summary>
        /// <param name="model">Пользователь</param>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _RecordService.GetAll());
        }

        /// <summary>
        /// Отображение всех пользователей
        /// </summary>
        /// <param name="model">Пользователь</param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var result = await _RecordService.GetById(id);
            var response = new Record()
            {
                RecordId = result.RecordId,
                UserId = result.UserId,
                ActivityId = result.ActivityId,
                RecordDate = result.RecordDate,
            };
            return Ok(response);
        }

        /// <summary>
        /// Создание нового пользователя
        /// </summary>
        /// <param name="model">Пользователь</param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> Add(CreateRecordRequest request)
        {
            var userDto = new Record()
            {
                UserId = request.Userid,
                ActivityId = request.Activityid,
                RecordDate = request.Recorddate,
            };
            await _RecordService.Create(userDto);
            return Ok();
        }

        /// <summary>
        /// Изменяет данные у пользователя
        /// </summary>
        /// <param name="model">Пользователь</param>
        /// <returns></returns>
        [HttpPut]
        public async Task<IActionResult> Update(CreateRecordRequest request)
        {
            var userDto = new Record()
            {
                UserId = request.Userid,
                ActivityId = request.Activityid,
                RecordDate = request.Recorddate,
            };
            await _RecordService.Create(userDto);
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
            var result = await _RecordService.GetById(id);
            var response = new Record()
            {
                RecordId = result.RecordId,
                UserId = result.UserId,
                ActivityId = result.ActivityId,
                RecordDate = result.RecordDate,
            };
            await _RecordService.Delete(id);
            return Ok(response);
        }
    }
}
