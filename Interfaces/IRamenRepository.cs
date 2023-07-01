using RamenKing.Models;

namespace RamenKing.Interfaces
{
    public interface IRamenRepository
    {
        IEnumerable<Ramen> GetAllRamen();
        Ramen GetRamenById(int Id);
    }
}
