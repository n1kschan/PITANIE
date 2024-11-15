using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface IMealFoodItemService
    {
        Task<List<MealFoodItem>> GetAll();
        Task<MealFoodItem> GetById(int id);
        Task Create(MealFoodItem model);
        Task Update(MealFoodItem model);
        Task Delete(int id);
    }
}
