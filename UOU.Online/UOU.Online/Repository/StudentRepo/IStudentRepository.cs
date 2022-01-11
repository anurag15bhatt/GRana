using UOU.Online.BusinessLayer.Models;

namespace UOU.Online.Repository
{
    interface IStudentRepository
    {
        Student GetStudent();

        int AddStudent(Student student);
        int UpdateStudent(Student student);
    }
}
