using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface IFoodItemCategoryService
    {
        Task<List<FoodItemCategory>> GetAll();
        Task<FoodItemCategory> GetById(int id);
        Task Create(FoodItemCategory model);
        Task Update(FoodItemCategory model);
        Task Delete(int id);
    }
}
