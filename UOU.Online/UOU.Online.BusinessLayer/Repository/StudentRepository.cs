using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using UOU.Online.BusinessLayer.Common;
using UOU.Online.BusinessLayer.Models;
namespace UOU.Online.BusinessLayer.Repository
{
    public class StudentRepository : IStudentRepository
    {
        SqlParameter[] _param;
        SqlFunctions _sf;
        DataTable _dataTable;
        public StudentRepository()
        {
            _sf = new SqlFunctions();
        }
       
        public int AddStudent(Student student)
        {
            _param = new SqlParameter[] {
                new SqlParameter("@Fname", student.FirstName),
                new SqlParameter("@Lname", student.LastName)
            };
            return Convert.ToInt32(_sf.executeScalerWithProc("ADDStudent", _param));
        }

       
        public Student GetStudent(int Id)
        {
                throw new NotImplementedException();
        }

        public List<Student> GetStudents()
        {
            int Id = 0;
            _param = new SqlParameter[] {
                new SqlParameter("@Id", Id)
            };
            _dataTable = new DataTable();
            _dataTable = _sf.returnDTWithProc_executeReader("GetStudents", _param);
            return GenericMethods.ConvertDataTable<Student>(_dataTable);
        }

        public int UpdateStudent(Student student)
        {
            throw new NotImplementedException();
        }
    }
}