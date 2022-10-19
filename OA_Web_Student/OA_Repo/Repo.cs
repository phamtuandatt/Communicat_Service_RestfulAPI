using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OA_Repo
{
    public class Repo<T> : IRepo<T> where T : class
    {
        // Define DbContext
        private readonly ApplicationDbContext _context;
        // Define DbSet<> -> Create table
        private DbSet<T> _table;

        public Repo(ApplicationDbContext context)
        {
            _context = context;
            _table = _context.Set<T>();
        }
    
        public void Delete(T item)
        {
            _table.Remove(item);
            _context.SaveChanges();
        }

        public T Get(int id)
        {
            return _table.Find(id);
        }

        public IEnumerable<T> GetAll()
        {
            return _table.AsEnumerable();
        }

        public void Insert(T item)
        {
            _table.Add(item);
            _context.SaveChanges();
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }

        public void Update(T item)
        {
            _context.Update(item);
            _context.SaveChanges();
        }
    }
}
