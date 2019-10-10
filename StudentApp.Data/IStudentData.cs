using StudentApp.Core;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace StudentApp.Data
{
    public interface IStudentData
    {
       IEnumerable<Student> GetStudentByName(string name);
        Student GetById(int id);
        Student Update(Student updateStudent);
        Student Add(Student newStudent);
        Student Delete(int id);
        int Commit();
    }
}
