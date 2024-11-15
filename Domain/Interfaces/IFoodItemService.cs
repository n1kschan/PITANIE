using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface IFoodItemService
    {
        Task<List<FoodItem>> GetAll();
        Task<FoodItem> GetById(int id);
        Task Create(FoodItem model);
        Task Update(FoodItem model);
        Task Delete(int id);
    }
}
