using System.Net.Sockets;
using System.Net;
using System.Text;
using System.Net;
using System.Net.Sockets;

namespace Orders_CRUD.TCP
{
    public static class ServerConnection
    {
        const string ip = "127.0.0.1";
        const int port = 8080;

        public static StringBuilder GetResponse(string request)
        {

            var tcpEndPoint = new IPEndPoint(IPAddress.Parse(ip), port);

            var tcpSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

            var data = Encoding.UTF8.GetBytes(request);

            tcpSocket.Connect(tcpEndPoint);
            tcpSocket.Send(data);

            var buffer = new byte[256];
            var size = 0;
            var answer = new StringBuilder();

            do
            {
                size = tcpSocket.Receive(buffer);
                answer.Append(Encoding.UTF8.GetString(buffer, 0, size));
            }
            while (tcpSocket.Available > 0);

            tcpSocket.Shutdown(SocketShutdown.Both);
            tcpSocket.Close();

            return answer;
        }
    }
}
