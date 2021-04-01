


using System.Net;
using System.Net.Sockets;
using System.Text;

namespace Utity
{
    public class update
    {
        static public byte[] result = new byte[1024];
        public static string server_version()
        {
            Socket ClientSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            try
            {
                ClientSocket.Connect(new IPEndPoint(IPAddress.Parse("39.96.6.12"), 10086));
            }
            catch
            {
                return null;
            }
            int receiveLenght = ClientSocket.Receive(result);
            ClientSocket.Shutdown(SocketShutdown.Both);
            ClientSocket.Close();
            return Encoding.ASCII.GetString(result, 0, 100);
        }
    }
}
