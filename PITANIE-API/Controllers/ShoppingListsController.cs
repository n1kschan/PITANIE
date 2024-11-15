using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Domain.Models;
using Domain.Interfaces;
using BusinessLogic.Services;
using Питание.Contracts.ShoppingList;

namespace Питание.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ShoppingListController : ControllerBase
    {
        private IShoppingListService _ShoppingListService;
        public ShoppingListController(IShoppingListService ShoppingListService)
        {
            _ShoppingListService = ShoppingListService;
        }

        /// <summary>
        /// Отображение всех пользователей
        /// </summary>
        /// <param name="model">Пользователь</param>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _ShoppingListService.GetAll());
        }

        /// <summary>
        /// Отображение всех пользователей
        /// </summary>
        /// <param name="model">Пользователь</param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var result = await _ShoppingListService.GetById(id);
            var response = new ShoppingList()
            {
                ShoppingListId = result.ShoppingListId,
                UserId = result.UserId,
                ListName = result.ListName,
                CreatedAt = result.CreatedAt,
            };
            return Ok(response);
        }

        /// <summary>
        /// Создание нового пользователя
        /// </summary>
        /// <param name="model">Пользователь</param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> Add(CreateShoppingListRequest request)
        {
            var userDto = new ShoppingList()
            {
                UserId = request.Userid,
                ListName = request.Listname,
                CreatedAt = request.Createdat,
            };
            await _ShoppingListService.Create(userDto);
            return Ok();
        }

        /// <summary>
        /// Изменяет данные у пользователя
        /// </summary>
        /// <param name="model">Пользователь</param>
        /// <returns></returns>
        [HttpPut]
        public async Task<IActionResult> Update(CreateShoppingListRequest request)
        {
            var userDto = new ShoppingList()
            {
                UserId = request.Userid,
                ListName = request.Listname,
                CreatedAt = request.Createdat,
            };
            await _ShoppingListService.Create(userDto);
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
            var result = await _ShoppingListService.GetById(id);
            var response = new ShoppingList()
            {
                ShoppingListId = result.ShoppingListId,
                UserId = result.UserId,
                ListName = result.ListName,
                CreatedAt = result.CreatedAt,
            };
            await _ShoppingListService.Delete(id);
            return Ok(response);
        }
    }
}
