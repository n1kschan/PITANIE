﻿using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface IAllergenService
    {
        Task<List<Allergen>> GetAll();
        Task<Allergen> GetById(int id);
        Task Create(Allergen model);
        Task Update(Allergen model);
        Task Delete(int id);
    }
}