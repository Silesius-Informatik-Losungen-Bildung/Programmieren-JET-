using Newtonsoft.Json;

var person = new Person { Name = "Max", Alter = 25 };
string json = JsonConvert.SerializeObject(person);
Console.WriteLine(json);

class Person
{
    public string Name { get; set; }
    public int Alter { get; set; }
}
