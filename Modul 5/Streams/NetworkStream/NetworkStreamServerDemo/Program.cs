using System.Net.Sockets;
using System.Net;
using System.Text;

namespace NetworkStreamServerDemo
{
    internal class Program
    {
        static void Main(string[] args)
        {
            TcpListener listener = new TcpListener(IPAddress.Any, 5000);
            listener.Start();
            Console.WriteLine("Warte auf Verbindung...");

            using (TcpClient client = listener.AcceptTcpClient())
            using (NetworkStream stream = client.GetStream())
            using (StreamReader reader = new StreamReader(stream, Encoding.UTF8))
            {
                string nachricht = reader.ReadLine();
                Console.WriteLine("Empfangen: " + nachricht);
            }

            listener.Stop();
        }
    }
}
