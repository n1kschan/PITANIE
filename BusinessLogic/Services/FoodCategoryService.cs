using Domain.Interfaces;
using Domain.Models;
using Domain.Wrapper;
using Microsoft.EntityFrameworkCore;

namespace BusinessLogic.Services
{
    public class FoodCategoryService : IFoodCategoryService
    {
        private IRepositoryWrapper _repositoryWrapper;

        public FoodCategoryService(IRepositoryWrapper repositoryWrapper)
        {
            _repositoryWrapper = repositoryWrapper;
        }

        public async Task<List<FoodCategory>> GetAll()
        {
            return await _repositoryWrapper.FoodCategory.FindAll();
        }

        public async Task<FoodCategory> GetById(int id)
        {
            var FoodCategory = await _repositoryWrapper.FoodCategory
                .FindByCondition(x => x.FoodCategoryId == id);
            return FoodCategory.First();
        }

        public async Task Create(FoodCategory model)
        {
            await _repositoryWrapper.FoodCategory.Create(model);
            await _repositoryWrapper.Save();
        }

        public async Task Update(FoodCategory model)
        {
            await _repositoryWrapper.FoodCategory.Update(model);
            await _repositoryWrapper.Save();
        }

        public async Task Delete(int id)
        {
            var FoodCategory = await _repositoryWrapper.FoodCategory
                .FindByCondition(x => x.FoodCategoryId == id);

            await _repositoryWrapper.FoodCategory.Delete(FoodCategory.First());
            await _repositoryWrapper.Save();
        }
    }
}