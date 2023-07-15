using System.Collections.Generic;

namespace SchoolManagerSystem.Model.Entities
{
    public class StudentCourse : BaseEntity
    {

        public string CourseId { get; set; }
        public ICollection<Course> Courses { get; set; }

        public ICollection<Student> Students { get; set; }
    }
}
