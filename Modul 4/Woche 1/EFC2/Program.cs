
using EFC2;

class Program
{
  
    static SandboxDbContext sandboxDbContext = new SandboxDbContext();

    static void Main()
    {
        // Einf�gen eines neuen Datensatzes
        var student = new Student() { Age = 18, Name = "Max Mustermann" };
        InsertStudent(student);

        // Abrufen vorhandener Datens�tze
        var students = GetAllStudents();
        students.ToList().ForEach(Console.WriteLine);

        //// Aktualisieren eines Datensatzes
        student = students.First(s => s.Name.IndexOf("Mustermann") > -1);
        student.Name = "Maxima Musterfrau";
        
        UpdateStudent(student);

        // L�schen eines Datensatzes
        DeleteStudent(student);

    }

    /// <summary>
    /// F�gt einen neuen Studenten in die Datenbank ein.
    /// </summary>
    static void InsertStudent(Student student)
    {
        sandboxDbContext.Students.Add(student); 
        sandboxDbContext.SaveChanges(); //!!!!!
    }

    /// <summary>
    /// Ruft alle Studenten aus der Datenbank ab.
    /// </summary>
    static IEnumerable<Student> GetAllStudents()
    {
        return sandboxDbContext.Students;
    }

    /// <summary>
    /// Aktualisiert die Daten eines bestimmten Studenten.
    /// </summary>
    static void UpdateStudent(Student student)
    {
        sandboxDbContext.SaveChanges();
    }

    /// <summary>
    /// L�scht einen bestimmten Studenten aus der Datenbank.
    /// </summary>
    static void DeleteStudent(Student student)
    {
        sandboxDbContext.Students.Remove(student);
        sandboxDbContext.SaveChanges(); //!!!!!
    }
}
