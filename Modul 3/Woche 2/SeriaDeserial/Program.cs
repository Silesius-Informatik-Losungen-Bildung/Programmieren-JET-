
using SeriaDeserial.Interfaces;
using SeriaDeserial.Logic;
using SeriaDeserial.Models;

var logic = new LogicPerson();

IPerson person = new Person
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




var json = logic.Serialize(person);
person = logic.Deserialize();



