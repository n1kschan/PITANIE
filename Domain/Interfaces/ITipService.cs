using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface ITipService
    {
        Task<List<Tip>> GetAll();
        Task<Tip> GetById(int id);
        Task Create(Tip model);
        Task Update(Tip model);
        Task Delete(int id);
    }
}
