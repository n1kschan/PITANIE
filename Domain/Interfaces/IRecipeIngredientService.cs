using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface IRecipeIngredientService
    {
        Task<List<RecipeIngredient>> GetAll();
        Task<RecipeIngredient> GetById(int id);
        Task Create(RecipeIngredient model);
        Task Update(RecipeIngredient model);
        Task Delete(int id);
    }
}
