using OA_Data;
using OA_Repo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OA_Serivce
{
    public class GradeService : IGradeService
    {
        // Define Repo
        private readonly IRepo<Grade> _dbContext;

        public GradeService(IRepo<Grade> dbContext)
        {
            _dbContext = dbContext;
        }

        public void Delete(int id)
        {
            _dbContext.Delete(GetGrade(id));
        }

        public Grade GetGrade(int id)
        {
            return _dbContext.Get(id);
        }

        public IEnumerable<Grade> GetGrades()
        {
            return _dbContext.GetAll();
        }

        public void Insert(Grade grade)
        {
            _dbContext.Insert(grade);
        }

        public void Update(Grade grade)
        {
            _dbContext.Update(grade);
        }
    }
}
