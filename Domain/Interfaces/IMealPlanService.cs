using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface IMealPlanService
    {
        Task<List<MealPlan>> GetAll();
        Task<MealPlan> GetById(int id);
        Task Create(MealPlan model);
        Task Update(MealPlan model);
        Task Delete(int id);
    }
}
