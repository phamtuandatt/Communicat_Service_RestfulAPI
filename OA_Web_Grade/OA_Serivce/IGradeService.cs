using OA_Data;

namespace OA_Serivce
{
    public interface IGradeService
    {
        IEnumerable<Grade> GetGrades();
        Grade GetGrade(int id);
        void Insert(Grade grade);
        void Update(Grade grade);
        void Delete(int id);

    }
}