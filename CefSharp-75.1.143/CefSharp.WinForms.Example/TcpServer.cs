using CefSharp.Example;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CefSharp.WinForms.Example
{

    public class TcpServer___Backup : ITcpClient
    {
        TcpListener server = null;
        public TcpServer___Backup()
        {
            server = new TcpListener(IPAddress.Loopback, 1501);
            server.Start();
            //StartListener();
        }

        public void StartListener()
        {
            try
            {
                while (true)
                {
                    Console.WriteLine("Waiting for a connection...");
                    TcpClient client = server.AcceptTcpClient();
                    Console.WriteLine("Connected!");
                    Thread t = new Thread(new ParameterizedThreadStart(HandleDeivce));
                    t.Start(client);
                }
            }
            catch (SocketException e)
            {
                Console.WriteLine("SocketException: {0}", e);
                server.Stop();
            }
        }

        NetworkStream m_streamCurrent = null;

        public IHandlerCallback HandlerCallback { get; set; }

        public void HandleDeivce(Object obj)
        {
            TcpClient client = (TcpClient)obj;
            var stream = client.GetStream();
            m_streamCurrent = stream;

            Byte[] bytes = new Byte[256 * 1024];
            int i = 0;
            string file;

            try
            {
                while ((i = stream.Read(bytes, 0, bytes.Length)) != 0)
                {
                    file = Encoding.UTF8.GetString(bytes, 0, i);
                    HandlerCallback.requestOcr(file);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception: {0}", e.ToString());
                client.Close();
            }
        }

        public void SendOcrResult(string data)
        {
            Byte[] reply = Encoding.UTF8.GetBytes(data);
            m_streamCurrent.Write(reply, 0, reply.Length);

        }
    }
}
