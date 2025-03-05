namespace Osterhase2
{
    public class Ei
    {
        public Ei()
        {
            Id = string.Join("",Guid.NewGuid().ToByteArray()).Substring(0,4) + "...";
        }

        public string Id { get; init; }
        public string Farbe { get; set; }
        public string Größe { get; set; }
    }
}