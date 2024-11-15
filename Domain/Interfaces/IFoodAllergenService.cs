using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface IFoodAllergenService
    {
        Task<List<FoodAllergen>> GetAll();
        Task<FoodAllergen> GetById(int id);
        Task Create(FoodAllergen model);
        Task Update(FoodAllergen model);
        Task Delete(int id);
    }
}
