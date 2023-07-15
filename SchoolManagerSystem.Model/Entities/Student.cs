namespace SchoolManagerSystem.Model.Entities
{
    public class Student : BaseEntity
    {
        public string UserId { get; set; }
        public ApplicationUser User { get; set; }

        public string AddressId { get; set; }
        public Address Address { get; set; }

        public string LevelId { get; set; }
        public Level Level { get; set; }

        public string StudentCourseId { get; set; }
        public StudentCourse StudentCourse { get; set; }

    }
}
