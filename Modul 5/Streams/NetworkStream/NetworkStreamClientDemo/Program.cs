using System.Net.Sockets;
using System.Text;

namespace NetworkStreamClientDemo
{
    internal class Program
    {
        static void Main(string[] args)
        {
            using (TcpClient client = new TcpClient("localhost", 5000))
            using (NetworkStream stream = client.GetStream())
            using (StreamWriter writer = new StreamWriter(stream, Encoding.UTF8))
            {
                writer.WriteLine("Hallo Server von NetworkStreamClientDemo!");
                writer.Flush();
            }
        }
    }
}
