
// Beispiel Serialisieren von Person-Objekt
var person = new Person
{
    Name = "Max Mustermann",
    GeburtsDatum = new DateOnly(1985, 1, 1),
    Gewicht = 80,
    Haarfarbe = Haarfarbe.Grau,
    Schuhgroesse = null,
    Adresse = new Adresse
    {
        Ort = "Wien",
        Plz = "1140",
        StrasseUndHausNr = "Fenzlgasse 1",
        BundesLand = null
    }
};

var jsonSerializerOptions = new JsonSerializerOptions
{
    PropertyNamingPolicy = JsonNamingPolicy., // Schreibeart von Namen der Konten
    WriteIndented = false, // Ob kompakte oder "schöne" (=eingerückte) Form verwendet wird
    DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull // Ob mit null gesetzte Eigenschaften generiert werden sollen
};

string jsonString = JsonSerializer.Serialize(person, jsonSerializerOptions);
Console.WriteLine("Serialisiertes JSON: " + jsonString);


// JSON-String in Person Objekt deserialisieren
jsonString = @"{
  ""name"": ""Max Mustermann"",
  ""GebDatum"": ""1985-01-01"",
  ""haarfarbe"": ""Grau"",
  ""Wohnadresse"": {
    ""strasseUndHausNr"": ""Fenzlgasse 1"",
    ""plz"": ""1140"",
    ""ort"": ""Wien""
  },
  ""schuhgroesse"": null
}";
person = JsonSerializer.Deserialize<Person>(jsonString, jsonSerializerOptions);
Console.WriteLine("Name: " + person?.Name);
Console.WriteLine("Alter: " + person?.Haarfarbe);
