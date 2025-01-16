using SeriaDeserial.Interfaces;
using SeriaDeserial.Models;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace SeriaDeserial.Logic
{

    public class LogicPerson: ILogicPerson
    {
        JsonSerializerOptions jsonSerializerOptions = new JsonSerializerOptions
        {
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
            WriteIndented = true,
            DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull,
            
        };

        const string pfad = @"..\..\..\Data\person.json";
        public IPerson? Deserialize()
        {
            var json = File.ReadAllText(pfad);
            var person = JsonSerializer.Deserialize<Person>(json, jsonSerializerOptions);
            if (person != null)
                return person;
            return null;
        }

        public string? Serialize(IPerson person)
        {
            var jsonString = JsonSerializer.Serialize(person);
            File.WriteAllText(pfad, jsonString);
            return JsonSerializer.Serialize(person, jsonSerializerOptions);
        }
    }
}
