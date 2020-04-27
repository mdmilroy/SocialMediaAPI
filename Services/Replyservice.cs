using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Sockets;
using System.Net;
using Data;
using Models;
using Models.Posts;

namespace Services
{
    public class ReplyService
    {
        const string SERVER_IP = "127.0.0.1";
        static void Main(string[] args)
        {
            //Create Dictionary
            Dictionary<string, string> dict = new Dictionary<string, string>();
            //---Read Text File containing commands ---
            StreamReader sr = new StreamReader(@"C:\Users\Desktop\potato.txt");
            string line;

            //Splits the text into commands:responses
            while ((line = sr.ReadLine()) != null)
            {
                string[] arr = line.Split(';');
                dict.Add(arr[0], arr[1]);
            }
            //Print dictionary TESTING FUNCTION
            foreach (KeyValuePair<string, string> kvp in dict)
            {
                Console.WriteLine("Command = {0} Response = {1}", kvp.Key, kvp.Value);
            }

            //---Input the port number for clients to conect---
            Console.Write("Input port" + System.Environment.NewLine);
            int PORT_NO = int.Parse(Console.ReadLine());

            //---listen at the specified IP and port no.---
            IPAddress localAdd = IPAddress.Parse(SERVER_IP);
            TcpListener listener = new TcpListener(localAdd, PORT_NO);
            Console.WriteLine("Listening for Commands");
            listener.Start();

            //---incoming client connected---
            TcpClient client = listener.AcceptTcpClient();

            //---get the incoming data through a network stream---
            NetworkStream nwStream = client.GetStream();
            byte[] buffer = new byte[client.ReceiveBufferSize];

            //---read incoming stream---
            int bytesRead = nwStream.Read(buffer, 0, client.ReceiveBufferSize);

            //---convert the command data received into a string---
            string dataReceived = Encoding.ASCII.GetString(buffer, 0, bytesRead);
            Console.WriteLine("Received Command : " + dataReceived);

            //---Search Command and send a response
            string Response;
            if (dict.TryGetValue(dataReceived, out Response))
            {
                Console.WriteLine(Response);
            }
            //---write back the response to the client---
            Console.WriteLine("Sending Response : " + Response);
            byte[] bytesToSend = ASCIIEncoding.ASCII.GetBytes(Response);
            nwStream.Write(bytesToSend, 0, bytesToSend.Length);
            Console.ReadLine();
        }
    }
}