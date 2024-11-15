using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface IShoppingListItemService
    {
        Task<List<ShoppingListItem>> GetAll();
        Task<ShoppingListItem> GetById(int id);
        Task Create(ShoppingListItem model);
        Task Update(ShoppingListItem model);
        Task Delete(int id);
    }
}
