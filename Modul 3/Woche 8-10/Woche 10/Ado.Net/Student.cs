using System.ComponentModel.DataAnnotations;

namespace Ado.Net
{
    public class Student
    {
        public int Id { get; init; }

        [StringLength(50)]
        public required string Name { get; set; }
        public int Age { get; set; }
    }
}
