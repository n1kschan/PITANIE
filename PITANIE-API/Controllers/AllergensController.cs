using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Domain.Models;
using Domain.Interfaces;
using BusinessLogic.Services;
using Питание.Contracts.Activity;
using Питание.Contracts.Allergen;

namespace Питание.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AllergenController : ControllerBase
    {
        private IAllergenService _allergenService;
        public AllergenController(IAllergenService allergenService)
        {
            _allergenService = allergenService;
        }

        /// <summary>
        /// Отображение всех пользователей
        /// </summary>
        /// <param name="model">Пользователь</param>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _allergenService.GetAll());
        }

        /// <summary>
        /// Отображение конкретного пользователя
        /// </summary>
        /// <param name="model">Пользователь</param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var result = await _allergenService.GetById(id);
            var response = new GetAllergenResponse()
            {
                Allergenid = result.AllergenId,
                AllergenName = result.AllergenName,
                Description = result.Description,
            };
            return Ok(response);
        }

        /// <summary>
        /// Создание нового пользователя
        /// </summary>
        /// <param name="model">Пользователь</param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> Add(CreateAllergenRequest request)
        {
            var userDto = new Allergen()
            {
                AllergenName = request.Allergenname,
                Description = request.Description,
            };
            await _allergenService.Create(userDto);
            return Ok();
        }

        /// <summary>
        /// Изменяет данные у пользователя
        /// </summary>
        /// <param name="model">Пользователь</param>
        /// <returns></returns>
        [HttpPut]
        public async Task<IActionResult> Update(UpdateAllergenRequest request)
        {
            var userDto = new Allergen()
            {
                AllergenName = request.Allergenname,
                Description = request.Description,
            };
            await _allergenService.Update(userDto);
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
            var result = await _allergenService.GetById(id);
            var response = new DeleteAllergenRequest()
            {
                Allergenid = result.AllergenId,
                AllergenName = result.AllergenName,
                Description = result.Description,
            };
            await _allergenService.Delete(id);
            return Ok(response);
        }
    }
}
