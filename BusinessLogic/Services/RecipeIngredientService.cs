using Domain.Interfaces;
using Domain.Models;
using Domain.Wrapper;
using Microsoft.EntityFrameworkCore;

namespace BusinessLogic.Services
{
    public class RecipeIngredientService : IRecipeIngredientService
    {
        private IRepositoryWrapper _repositoryWrapper;

        public RecipeIngredientService(IRepositoryWrapper repositoryWrapper)
        {
            _repositoryWrapper = repositoryWrapper;
        }

        public async Task<List<RecipeIngredient>> GetAll()
        {
            return await _repositoryWrapper.RecipeIngredient.FindAll();
        }

        public async Task<RecipeIngredient> GetById(int id)
        {
            var RecipeIngredient = await _repositoryWrapper.RecipeIngredient
                .FindByCondition(x => x.RecipeIngredientId == id);
            return RecipeIngredient.First();
        }

        public async Task Create(RecipeIngredient model)
        {
            await _repositoryWrapper.RecipeIngredient.Create(model);
            await _repositoryWrapper.Save();
        }

        public async Task Update(RecipeIngredient model)
        {
            await _repositoryWrapper.RecipeIngredient.Update(model);
            await _repositoryWrapper.Save();
        }

        public async Task Delete(int id)
        {
            var RecipeIngredient = await _repositoryWrapper.RecipeIngredient
                .FindByCondition(x => x.RecipeIngredientId == id);

            await _repositoryWrapper.RecipeIngredient.Delete(RecipeIngredient.First());
            await _repositoryWrapper.Save();
        }
    }
}