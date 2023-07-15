using System.Collections.Generic;

namespace SchoolManagerSystem.Model.Entities
{
    public class Course : BaseEntity
    {

        public string CourseName { get; set; }
        public ICollection<StudentCourse> StudentCourses { get; set; }

    }
}
