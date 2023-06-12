using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Backend.Models.DTOs;

namespace Backend.Services.Interfaces
{
    public interface ITransitService
    {
        public Task<List<TransitsGet>> GetTransitsByDay(DateTime date, List<int> linkId);
    }
}