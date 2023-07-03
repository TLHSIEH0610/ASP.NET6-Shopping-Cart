using System.Diagnostics;
using RamenKing.Models;

namespace RamenKing.Interfaces
{
    public interface IRamenRepository
    {
        Task<IEnumerable<Ramen>> GetAllRamen();
        Task<Ramen> GetRamenById(int Id);
        bool Add(Ramen ramen);
        bool Update(Ramen ramen);
        bool Delete(Ramen ramen);
        bool Save();
    }
}
