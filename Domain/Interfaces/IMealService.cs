using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface IMealService
    {
        Task<List<Meal>> GetAll();
        Task<Meal> GetById(int id);
        Task Create(Meal model);
        Task Update(Meal model);
        Task Delete(int id);
    }
}
