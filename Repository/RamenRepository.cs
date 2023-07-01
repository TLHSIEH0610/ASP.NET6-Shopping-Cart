using System;
using System.Collections.Generic;
using RamenKing.Data;
using RamenKing.Models;
using RamenKing.Interfaces;
using System.Linq;

namespace RamenKing.Repository
{
    public class RamenRepository : IRamenRepository
    {

        private readonly AppDbContext _context;

        public RamenRepository(AppDbContext ramenContext)
        {
            _context = ramenContext;
        }

        public IEnumerable<Ramen> GetAllRamen()
        {
            return _context.Ramens.ToList();
        }

        public Ramen GetRamenById(int Id)
        {
            return _context.Ramens.FirstOrDefault((r) => r.Id == Id);
        }
    }
}

