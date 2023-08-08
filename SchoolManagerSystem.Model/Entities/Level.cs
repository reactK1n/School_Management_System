using System.Collections.Generic;

namespace SchoolManagerSystem.Model.Entities
{
    public class Level : BaseEntity
    {
        public string LevelName { get; set; }

        //navigation properties
        public ICollection<Student> Students { get; set; }

        public ICollection<Course> Courses { get; set; }
    }
}
