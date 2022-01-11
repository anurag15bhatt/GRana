using System.Collections.Generic;
using UOU.Online.BusinessLayer.Models;

namespace UOU.Online.BusinessLayer.Repository
{
    public interface IStudentRepository
    {
        Student GetStudent(int Id);

        int AddStudent(Student student);
        int UpdateStudent(Student student);
        List<Student> GetStudents();
    }
}
