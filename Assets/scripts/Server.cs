
using System;
using WebSocketSharp;
using WebSocketSharp.Server;

namespace ServerSpace
{
    public class Laputa : WebSocketBehavior
    {
        protected override void OnMessage(MessageEventArgs e)
        {
            var msg = e.Data == "BALUS"
                      ? "I've been balused already..."
                      : "I'm not available now.";

            Send(msg);
        }
    }

    public class Server
    {
        private WebSocketServer wssv;
        public Server()
        {
            wssv = new WebSocketServer(9999);
            wssv.AddWebSocketService<Laputa>("/Laputa");
            wssv.AddWebSocketService<MainController>("/Control");
            wssv.Start();
            Console.ReadKey(true);
            if (wssv.IsListening)
            {
                Console.WriteLine("Listening on port {0}, and providing WebSocket services:", wssv.Port);
                foreach (var path in wssv.WebSocketServices.Paths)
                    Console.WriteLine("- {0}", path);
            }
            //wssv.Stop();
        }

        public void OnOpen()
        {

        }
    }
}
