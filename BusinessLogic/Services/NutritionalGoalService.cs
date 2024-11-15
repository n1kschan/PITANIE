using Domain.Interfaces;
using Domain.Models;
using Domain.Wrapper;
using Microsoft.EntityFrameworkCore;

namespace BusinessLogic.Services
{
    public class NutritionalGoalService : INutritionalGoalService
    {
        private IRepositoryWrapper _repositoryWrapper;

        public NutritionalGoalService(IRepositoryWrapper repositoryWrapper)
        {
            _repositoryWrapper = repositoryWrapper;
        }

        public async Task<List<NutritionalGoal>> GetAll()
        {
            return await _repositoryWrapper.NutritionalGoal.FindAll();
        }

        public async Task<NutritionalGoal> GetById(int id)
        {
            var NutritionalGoal = await _repositoryWrapper.NutritionalGoal
                .FindByCondition(x => x.GoalId == id);
            return NutritionalGoal.First();
        }

        public async Task Create(NutritionalGoal model)
        {
            await _repositoryWrapper.NutritionalGoal.Create(model);
            await _repositoryWrapper.Save();
        }

        public async Task Update(NutritionalGoal model)
        {
            await _repositoryWrapper.NutritionalGoal.Update(model);
            await _repositoryWrapper.Save();
        }

        public async Task Delete(int id)
        {
            var NutritionalGoal = await _repositoryWrapper.NutritionalGoal
                .FindByCondition(x => x.GoalId == id);

            await _repositoryWrapper.NutritionalGoal.Delete(NutritionalGoal.First());
            await _repositoryWrapper.Save();
        }
    }
}