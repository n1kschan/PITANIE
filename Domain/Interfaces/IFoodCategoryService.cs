using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface IFoodCategoryService
    {
        Task<List<FoodCategory>> GetAll();
        Task<FoodCategory> GetById(int id);
        Task Create(FoodCategory model);
        Task Update(FoodCategory model);
        Task Delete(int id);
    }
}
