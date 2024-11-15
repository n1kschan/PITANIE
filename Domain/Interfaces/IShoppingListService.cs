using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface IShoppingListService
    {
        Task<List<ShoppingList>> GetAll();
        Task<ShoppingList> GetById(int id);
        Task Create(ShoppingList model);
        Task Update(ShoppingList model);
        Task Delete(int id);
    }
}
