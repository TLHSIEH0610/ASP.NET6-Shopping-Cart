using System;


namespace RamenKing.Models
{
    public interface IRamenRepository
    {
        IEnumerable<Ramen> GetAllRamen();
        Ramen GetRamenById(int Id);

    }

    public class RamenRepository : IRamenRepository
    {
        private List<Ramen> _ramen;


        public RamenRepository()
        {
            if (_ramen == null)
            {
                InitializeRamen();
            }
        }

        private void InitializeRamen()
        {
            _ramen = new List<Ramen>
            {
               new Ramen { Id = 1, Name = "First", Price = 12, Description = "Good", ImageURL=""},
                new Ramen { Id = 2, Name = "Second", Price = 10,  Description = "SooSOo", ImageURL=""},
            };
        }

        public IEnumerable<Models.Ramen> GetAllRamen()
        {
            return _ramen;
        }

        public Models.Ramen GetRamenById(int Id)
        {
            return _ramen.FirstOrDefault((r) => r.Id == Id);
        }
    }
}

