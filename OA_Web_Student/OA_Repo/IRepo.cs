using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OA_Repo
{
    public interface IRepo<T> where T : class
    {
        IEnumerable<T> GetAll();
        T Get(int id);
        void Insert(T item);
        void Update(T item);
        void Delete(T item);
        void SaveChanges();
    }
}
