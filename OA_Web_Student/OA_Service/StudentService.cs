using OA_Data;
using OA_Repo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OA_Service
{
    public class StudentService : IStudentService
    {
        // Define Repo
        private readonly IRepo<Student> _dbContext;

        public StudentService(IRepo<Student> dbContext)
        {
            _dbContext = dbContext;
        }

        public void DeleteStudent(int id)
        {
            _dbContext.Delete(GetStudent(id));
        }

        public Student GetStudent(int id)
        {
            return _dbContext.Get(id);
        }

        public IEnumerable<Student> GetStudents()
        {
            return _dbContext.GetAll();
        }

        public Student InsertStudent(Student student)
        {
            _dbContext.Insert(student);
            return student;
        }

        public void UpdateStudent(Student student)
        {
            _dbContext.Update(student);
        }
    }
}
