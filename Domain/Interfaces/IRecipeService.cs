using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface IRecipeService
    {
        Task<List<Recipe>> GetAll();
        Task<Recipe> GetById(int id);
        Task Create(Recipe model);
        Task Update(Recipe model);
        Task Delete(int id);
    }
}
