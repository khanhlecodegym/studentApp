using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using StudentApp.Core;
using StudentApp.Data;

namespace StudentApp.Pages.Students
{
    public class EditModel : PageModel
    {
        private readonly IStudentData studentData;
        private readonly IHtmlHelper htmlHelper;

        [BindProperty]
        public Student Student { get; set; }
        public IEnumerable<SelectListItem> Skills { get; set; }

        public EditModel(IStudentData studentData, IHtmlHelper htmlHelper)
        {
            this.studentData = studentData;
            this.htmlHelper = htmlHelper;
        }
        public IActionResult OnGet(int? studentId)
        {
            Skills = htmlHelper.GetEnumSelectList<Skill>();
            if (studentId.HasValue)
            {
                Student = studentData.GetById(studentId.Value);
            }
            else
            {
                Student = new Student();
            }

            if (Student == null)
            {
                return RedirectToPage("./NotFound");
            }

            return Page();
            
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                Skills = htmlHelper.GetEnumSelectList<Skill>();
                return Page();
            }

            if(Student.Id > 0)
            {
                studentData.Update(Student);
            } else
            {
                studentData.Add(Student);
            }

            studentData.Commit();

            return RedirectToPage("./Detail", new { studentId = Student.Id });
        }
    }
}