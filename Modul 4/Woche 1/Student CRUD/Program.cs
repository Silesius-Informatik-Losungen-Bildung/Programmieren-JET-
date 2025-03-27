using Student_CRUD;


using var studentContext = new StudentContext();

// Einfügen eines neuen Datensatzes
var student = new Student() { Age = 18, Name = "Max Mustermann" };
InsertStudent(student);

// Abrufen und Anzeigen der vorhandenen Datensätze
Console.WriteLine("Aktuelle Liste der Studenten:");
var students = GetAllStudents();
foreach(var item in students)
    Console.WriteLine(item.Id + ", " + item.Name);


// Aktualisieren eines Datensatzes
student = students.First(s => s.Name.IndexOf("Mustermann") > -1); // Auswahl-Kondition (wird in SQL-WHERE ... übersetzt)
student.Name = "Maxima Musterfrau";
UpdateStudent(student);

// Löschen eines Datensatzes
student = students.OrderByDescending(x=> x.Id).First(s => s.Id % 2 == 0); // Löschkondition (wird in SQL-WHERE ... übersetzt)
DeleteStudent(student);


void InsertStudent(Student student)
{
    var students = studentContext.Students.Add(student);
    studentContext.SaveChanges(); // Commit
}

IEnumerable<Student> GetAllStudents()
{
    return studentContext.Students.ToList(); // mit .ToList() wird SQL-SELECT-Statemant ausgeführt
}

void UpdateStudent(Student student)
{
    studentContext.SaveChanges(); // Commit
}

void DeleteStudent(Student student)
{
    studentContext.Remove(student);
    studentContext.SaveChanges(); // Commit
}



