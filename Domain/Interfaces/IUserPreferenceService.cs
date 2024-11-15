using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface IUserPreferenceService
    {
        Task<List<UserPreference>> GetAll();
        Task<UserPreference> GetById(int id);
        Task Create(UserPreference model);
        Task Update(UserPreference model);
        Task Delete(int id);
    }
}
