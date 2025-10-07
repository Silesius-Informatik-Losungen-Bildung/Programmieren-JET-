using System.ComponentModel.DataAnnotations;

namespace EFC2
{
    public class Student
    {
        public int StudentId { get; init; }

        [StringLength(50)]
        public string Name { get; set; } = null!;
        public int Age { get; set; }
        public DateTime? BirthDay { get; set; }

        public override string ToString()
        {
            return $"{Name} ({Age})";
        }
    }
}
