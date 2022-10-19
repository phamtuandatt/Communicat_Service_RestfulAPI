using OA_Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OA_Service
{
    public interface IStudentService
    {
        // Get list student
        IEnumerable<Student> GetStudents();
        
        // Get Student
        Student GetStudent(int id);

        // Insert Student
        void InsertStudent(Student student);

        // Update Student
        void UpdateStudent(Student student);

        // Delete Student
        void DeleteStudent(int id);

    }
}
