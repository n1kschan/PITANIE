using Domain.Interfaces;
using Domain.Models;
using Domain.Wrapper;
using Microsoft.EntityFrameworkCore;

namespace BusinessLogic.Services
{
    public class FavoriteRecipeService : IFavoriteRecipeService
    {
        private IRepositoryWrapper _repositoryWrapper;

        public FavoriteRecipeService(IRepositoryWrapper repositoryWrapper)
        {
            _repositoryWrapper = repositoryWrapper;
        }

        public async Task<List<FavoriteRecipe>> GetAll()
        {
            return await _repositoryWrapper.FavoriteRecipe.FindAll();
        }

        public async Task<FavoriteRecipe> GetById(int id)
        {
            var FavoriteRecipe = await _repositoryWrapper.FavoriteRecipe
                .FindByCondition(x => x.FavoriteRecipeId == id);
            return FavoriteRecipe.First();
        }

        public async Task Create(FavoriteRecipe model)
        {
            await _repositoryWrapper.FavoriteRecipe.Create(model);
            await _repositoryWrapper.Save();
        }

        public async Task Update(FavoriteRecipe model)
        {
            await _repositoryWrapper.FavoriteRecipe.Update(model);
            await _repositoryWrapper.Save();
        }

        public async Task Delete(int id)
        {
            var FavoriteRecipe = await _repositoryWrapper.FavoriteRecipe
                .FindByCondition(x => x.FavoriteRecipeId == id);

            await _repositoryWrapper.FavoriteRecipe.Delete(FavoriteRecipe.First());
            await _repositoryWrapper.Save();
        }
    }
}