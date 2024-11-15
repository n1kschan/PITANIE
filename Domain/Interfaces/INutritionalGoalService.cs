using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface INutritionalGoalService
    {
        Task<List<NutritionalGoal>> GetAll();
        Task<NutritionalGoal> GetById(int id);
        Task Create(NutritionalGoal model);
        Task Update(NutritionalGoal model);
        Task Delete(int id);
    }
}
