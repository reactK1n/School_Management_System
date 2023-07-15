using System.Collections.Generic;

namespace SchoolManagerSystem.Model.Entities
{
    public class Level : BaseEntity
    {
        public string LevelName { get; set; }
        public ICollection<Student> Students { get; set; }
    }
}
