using Microsoft.EntityFrameworkCore;
using StudentApp.Core;
using System.Collections.Generic;
using System.Linq;

namespace StudentApp.Data
{
    public class SqlStudentData : IStudentData
    {
        private readonly StudentAppDbContext dbContext;

        public SqlStudentData(StudentAppDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public Student Add(Student newStudent)
        {
            dbContext.Add(newStudent);
            return newStudent;
        }

        public int Commit()
        {
            return dbContext.SaveChanges();
        }

        public Student Delete(int id)
        {
            var student = GetById(id);
            if (student != null)
            {
                dbContext.Students.Remove(student);
            }

            return student;
        }

        public Student GetById(int id)
        {
            return dbContext.Students.Find(id);
        }

        public IEnumerable<Student> GetStudentByName(string name)
        {
            var result = from s in dbContext.Students
                         where string.IsNullOrEmpty(name) || s.Name.StartsWith(name)
                         select s;

            return result;
        }

        public Student Update(Student updateStudent)
        {
            var entity = dbContext.Students.Attach(updateStudent);
            entity.State = EntityState.Modified;

            return updateStudent;
        }
    }
}
