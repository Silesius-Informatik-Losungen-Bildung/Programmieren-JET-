using Ado.Net;
using Microsoft.Data.SqlClient;

class Program
{
    static string connectionString = "Data Source=DESKTOP-KCGE85K\\SQLEXPRESS;Initial Catalog=Sandbox;Integrated Security=True;Encrypt=False";

    static void Main()
    {
        // Einfügen eines neuen Datensatzes
        var student = new Student() { Age = 18, Name = "Max Mustermann" };
        InsertStudent(student);

        // Abrufen vorhandener Datensätze
        var students = GetAllStudents();

        // Aktualisieren eines Datensatzes
        student = students.First(s => s.Name.IndexOf("Mustermann") > -1);
        student.Name = "Maxima Musterfrau";
        UpdateStudent(student);

        // Löschen eines Datensatzes
        DeleteStudent(student);

    }

    /// <summary>
    /// Fügt einen neuen Studenten in die Datenbank ein.
    /// </summary>
    static void InsertStudent(Student student)
    {
        using (SqlConnection sqlConnection = new SqlConnection(connectionString))
        {
            string query = "INSERT INTO Students (Name, Age) VALUES (@Name, @Age)";
            SqlCommand sqlCommand = new SqlCommand(query, sqlConnection);

            // Parameter hinzufügen, um SQL-Injection zu vermeiden
            sqlCommand.Parameters.AddWithValue("@Name", student.Name);
            sqlCommand.Parameters.AddWithValue("@Age", student.Age);

            sqlConnection.Open();
            int rowsAffected = sqlCommand.ExecuteNonQuery();

            Console.WriteLine($"{rowsAffected} Datensatz(e) hinzugefügt.");
        }
    }

    /// <summary>
    /// Ruft alle Studenten aus der Datenbank ab.
    /// </summary>
    static IEnumerable<Student> GetAllStudents()
    {
        var students = new List<Student>();
        using (SqlConnection sqlConnection = new SqlConnection(connectionString))
        {
            string query = "SELECT * FROM Students";
            SqlCommand sqlCommand = new SqlCommand(query, sqlConnection);

            sqlConnection.Open();

            SqlDataReader reader = sqlCommand.ExecuteReader();

            while (reader.Read())
            {
                var student = new Student() 
                    {
                        Id = reader.GetInt32(0),
                        Name = reader.GetString(1), 
                        Age = reader.GetInt32(2) 
                     };
                students.Add(student);
            }

            reader.Close();
        }
        return students;
    }

    /// <summary>
    /// Aktualisiert die Daten eines bestimmten Studenten.
    /// </summary>
    static void UpdateStudent(Student student)
    {
        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            string query = "UPDATE Students SET Name = @Name, Age = @Age WHERE Id = @Id";
            SqlCommand sqlCommand = new SqlCommand(query, connection);

            // Parameter hinzufügen
            sqlCommand.Parameters.AddWithValue("@Name", student.Name);
            sqlCommand.Parameters.AddWithValue("@Age", student.Age);
            sqlCommand.Parameters.AddWithValue("@Id", student.Id);

            connection.Open();
            int rowsAffected = sqlCommand.ExecuteNonQuery();

            Console.WriteLine($"{rowsAffected} Datensatz(e) aktualisiert.");
        }
    }

    /// <summary>
    /// Löscht einen bestimmten Studenten aus der Datenbank.
    /// </summary>
    static void DeleteStudent(Student student)
    {
        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            string query = "DELETE FROM Students WHERE Id = @Id;";
            SqlCommand sqlCommand = new SqlCommand(query, connection);

            // Parameter hinzufügen
            sqlCommand.Parameters.AddWithValue("@Id", student.Id);

            connection.Open();
            int rowsAffected = sqlCommand.ExecuteNonQuery();

            Console.WriteLine($"{rowsAffected} Datensatz(e) gelöscht.");
        }
    }
}
