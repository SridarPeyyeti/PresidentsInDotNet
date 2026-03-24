using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using PresidentsApp.Interfaces;
using PresidentsApp.Models;

namespace PresidentsApp.Repositories
{
    public class JsonPresidentRepository : IPresidentRepository
    {
        private readonly string _filePath;

        public JsonPresidentRepository(string filePath)
        {
            _filePath = Path.Combine(Directory.GetCurrentDirectory(), filePath);
        }

        public List<President> LoadPresidents()
        {
            var json = File.ReadAllText(_filePath);
            return JsonSerializer.Deserialize<List<President>>(json);
        }
    }
}
