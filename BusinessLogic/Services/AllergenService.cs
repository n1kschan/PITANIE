using Domain.Interfaces;
using Domain.Models;
using Domain.Wrapper;
using Microsoft.EntityFrameworkCore;

namespace BusinessLogic.Services
{
    public class AllergenService : IAllergenService
    {
        private IRepositoryWrapper _repositoryWrapper;

        public AllergenService(IRepositoryWrapper repositoryWrapper)
        {
            _repositoryWrapper = repositoryWrapper;
        }

        public async Task<List<Allergen>> GetAll()
        {
            return await _repositoryWrapper.Allergen.FindAll();
        }

        public async Task<Allergen> GetById(int id)
        {
            var Allergen = await _repositoryWrapper.Allergen
                .FindByCondition(x => x.AllergenId == id);
            return Allergen.First();
        }

        public async Task Create(Allergen model)
        {
            await _repositoryWrapper.Allergen.Create(model);
            await _repositoryWrapper.Save();
        }

        public async Task Update(Allergen model)
        {
            await _repositoryWrapper.Allergen.Update(model);
            await _repositoryWrapper.Save();
        }

        public async Task Delete(int id)
        {
            var Allergen = await _repositoryWrapper.Allergen
                .FindByCondition(x => x.AllergenId == id);

            await _repositoryWrapper.Allergen.Delete(Allergen.First());
            await _repositoryWrapper.Save();
        }
    }
}
