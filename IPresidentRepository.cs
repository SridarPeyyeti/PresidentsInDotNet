using System.Collections.Generic;
using PresidentsApp.Models;

namespace PresidentsApp.Interfaces
{
    public interface IPresidentRepository
    {
        List<President> LoadPresidents();
    }
}
