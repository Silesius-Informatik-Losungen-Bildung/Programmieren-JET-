
namespace EFC
{
    internal class Program
    {

        static SandboxContext sandboxContext = new SandboxContext();
        static void Main(string[] args)
        {
            Grundlagen();
            EFCUebungen();
        }

        private static void EFCUebungen()
        {
            
        }

        private static void Grundlagen()
        {
            // Einfügen eines neuen Datensatzes
            var student = new Student() { Age = 18, Name = "Max Mustermann" };
            InsertStudent(student);


            // Abrufen vorhandener Datensätze
            var students = GetAllStudents();
            foreach (var s in students)
            {
                Console.WriteLine(s.Name);
            }

            // Aktualisieren eines Datensatzes
            student = students.First(s => s.Name.IndexOf("Sandra") > -1);
            //student.Name = "Sandra";
            UpdateStudent(student);

            // Löschen eines Datensatzes
            DeleteStudent(student);
        }

        private static void DeleteStudent(Student student)
        {
            sandboxContext.Students.Remove(student);
            sandboxContext.SaveChanges();
        }

        private static void UpdateStudent(Student student)
        {
            sandboxContext.SaveChanges();
        }

        private static List<Student> GetAllStudents()
        {
           return sandboxContext.Students.ToList();
        }

        private static void InsertStudent(Student student)
        {
            sandboxContext.Add(student);
            sandboxContext.SaveChanges();
        }
    }
}
