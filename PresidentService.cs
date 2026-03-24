using System;
using System.Collections.Generic;
using System.Linq;
using PresidentsApp.Interfaces;
using PresidentsApp.Models;

namespace PresidentsApp.Services
{
    public class PresidentService
    {
        private readonly List<President> _presidents;

        public PresidentService(IPresidentRepository repo)
        {
            _presidents = repo.LoadPresidents();
        }

        public List<President> ListByNumber()
        {
            return _presidents.OrderBy(p => p.Number).ToList();
        }

        public List<President> ListByLastName()
        {
            return _presidents.OrderBy(p => p.Name.Split(' ').Last()).ToList();
        }

        public List<President> SearchByName(string substring)
        {
            var result = _presidents
                .Where(p => p.Name.ToLower().Contains(substring.ToLower()))
                .OrderBy(p => p.Name)
                .ToList();

            if (!result.Any())
                throw new Exception("No president found");

            return result;
        }

        public President GetByNumber(int number)
        {
            var result = _presidents.FirstOrDefault(p => p.Number == number);
            if (result == null)
                throw new Exception("President not found");

            return result;
        }
    }
}
