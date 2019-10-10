using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace StudentApp.Core
{
    public class Student
    {
        public int Id { get; set; }

        [Required, StringLength(2)]
        public string Name { get; set; }

        [Required, StringLength(255)]
        public string Address { get; set; }

        public Skill Skill { get; set; }

    }
}
