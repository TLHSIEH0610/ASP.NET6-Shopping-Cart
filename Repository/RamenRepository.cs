using System;
using System.Collections.Generic;
using RamenKing.Data;
using RamenKing.Models;
using RamenKing.Interfaces;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace RamenKing.Repository
{
    public class RamenRepository : IRamenRepository
    {

        private readonly AppDbContext _context;


        public RamenRepository(AppDbContext ramenContext)
        {
            _context = ramenContext;
        }


        public async Task<IEnumerable<Ramen>> GetAllRamen()
        {
            return await _context.Ramens.ToListAsync();
        }


        public async Task<Ramen> GetRamenById(int Id)
        {
            return await _context.Ramens.AsNoTracking().FirstOrDefaultAsync((r) => r.Id == Id);
        }


        public bool Add(Ramen ramen)
        {
            _context.Add(ramen);
            return Save();
        }


        public bool Update(Ramen ramen)
        {
            _context.Update(ramen);
            return Save();
        }


        public bool Delete(Ramen ramen)
        {
            _context.Remove(ramen);
            return Save();
        }


        public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved > 0;
        }
    }
}

