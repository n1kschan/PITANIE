using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface IFavoriteRecipeService
    {
        Task<List<FavoriteRecipe>> GetAll();
        Task<FavoriteRecipe> GetById(int id);
        Task Create(FavoriteRecipe model);
        Task Update(FavoriteRecipe model);
        Task Delete(int id);
    }
}
