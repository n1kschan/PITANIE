using Domain.Interfaces;
using Domain.Models;
using Domain.Wrapper;
using Microsoft.EntityFrameworkCore;

namespace BusinessLogic.Services
{
    public class MealService : IMealService
    {
        private IRepositoryWrapper _repositoryWrapper;

        public MealService(IRepositoryWrapper repositoryWrapper)
        {
            _repositoryWrapper = repositoryWrapper;
        }

        public async Task<List<Meal>> GetAll()
        {
            return await _repositoryWrapper.Meal.FindAll();
        }

        public async Task<Meal> GetById(int id)
        {
            var Meal = await _repositoryWrapper.Meal
                .FindByCondition(x => x.MealId == id);
            return Meal.First();
        }

        public async Task Create(Meal model)
        {
            await _repositoryWrapper.Meal.Create(model);
            await _repositoryWrapper.Save();
        }

        public async Task Update(Meal model)
        {
            await _repositoryWrapper.Meal.Update(model);
            await _repositoryWrapper.Save();
        }

        public async Task Delete(int id)
        {
            var Meal = await _repositoryWrapper.Meal
                .FindByCondition(x => x.MealId == id);

            await _repositoryWrapper.Meal.Delete(Meal.First());
            await _repositoryWrapper.Save();
        }
    }
}