using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Domain.Models;
using Domain.Interfaces;
using BusinessLogic.Services;
using Питание.Contracts.ShoppingListItem;

namespace Питание.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ShoppingListItemController : ControllerBase
    {
        private IShoppingListItemService _ShoppingListItemService;
        public ShoppingListItemController(IShoppingListItemService ShoppingListItemService)
        {
            _ShoppingListItemService = ShoppingListItemService;
        }

        /// <summary>
        /// Отображение всех пользователей
        /// </summary>
        /// <param name="model">Пользователь</param>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _ShoppingListItemService.GetAll());
        }

        /// <summary>
        /// Отображение всех пользователей
        /// </summary>
        /// <param name="model">Пользователь</param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var result = await _ShoppingListItemService.GetById(id);
            var response = new ShoppingListItem()
            {
                ShoppingListItemId = result.ShoppingListItemId,
                ShoppingListId = result.ShoppingListId,
                FoodItem = result.FoodItem,
                Quantity = result.Quantity,
            };
            return Ok(response);
        }

        /// <summary>
        /// Создание нового пользователя
        /// </summary>
        /// <param name="model">Пользователь</param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> Add(CreateShoppingListItemRequest request)
        {
            var userDto = new ShoppingListItem()
            {
                ShoppingListId = request.Shoppinglistid,
                FoodItemId = request.FoodItemid,
                Quantity = request.Quantity,
            };
            await _ShoppingListItemService.Create(userDto);
            return Ok();
        }

        /// <summary>
        /// Изменяет данные у пользователя
        /// </summary>
        /// <param name="model">Пользователь</param>
        /// <returns></returns>
        [HttpPut]
        public async Task<IActionResult> Update(CreateShoppingListItemRequest request)
        {
            var userDto = new ShoppingListItem()
            {
                ShoppingListId = request.Shoppinglistid,
                FoodItemId = request.FoodItemid,
                Quantity = request.Quantity,
            };
            await _ShoppingListItemService.Create(userDto);
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
            var result = await _ShoppingListItemService.GetById(id);
            var response = new ShoppingListItem()
            {
                ShoppingListItemId = result.ShoppingListItemId,
                ShoppingListId = result.ShoppingListId,
                FoodItem = result.FoodItem,
                Quantity = result.Quantity,
            };
            await _ShoppingListItemService.Delete(id);
            return Ok(response);
        }
    }
}
