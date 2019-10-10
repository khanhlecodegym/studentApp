using Microsoft.EntityFrameworkCore;
using StudentApp.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace StudentApp.Data
{
    public class StudentAppDbContext :DbContext
    {
        public StudentAppDbContext(DbContextOptions<StudentAppDbContext> options) : base(options)
        {

        }

        public DbSet<Student> Students { get; set; }
    }
}
