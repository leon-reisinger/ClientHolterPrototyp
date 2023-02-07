using System.Net;
using System.Net.Sockets;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

string localIp = LocalIPAddress();


app.MapGet("/", () => "Hello World!");

app.MapGet("/kz1", () => 111);
app.MapGet("/kz2", () => 22.22);

app.Run($"http://{localIp}:5000");

static string LocalIPAddress()
{
  using (Socket socket = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, 0))
  {
    socket.Connect("8.8.8.8", 65530);
    IPEndPoint? endPoint = socket.LocalEndPoint as IPEndPoint;
    if (endPoint != null)
    {
      return endPoint.Address.ToString();
    }
    else
    {
      return "127.0.0.1";
    }
  }
}
