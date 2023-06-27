using System;
using System.Collections.Generic;

namespace RamenKing.Models
{
    public interface IRamenRepository
    {
        IEnumerable<Ramen> GetAllRamen();
        Ramen GetRamenById(int Id);

    }

    public class RamenRepository : IRamenRepository
    {

        private readonly MvcRamenContext _context;


        public RamenRepository(MvcRamenContext ramenContext)
        {
            _context = ramenContext;
        }



        public IEnumerable<Ramen> GetAllRamen()
        {
            return _context.Ramen;
        }

        public Ramen GetRamenById(int Id)
        {
            return _context.Ramen.FirstOrDefault((r) => r.Id == Id);
        }
    }
}

