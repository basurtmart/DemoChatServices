using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Threading.Tasks;
using Client_Chat.Models;
using Microsoft.AspNet.SignalR.Client;

namespace Client_Chat.Services
{
    public class ChatServices : IChatServices
    {
        private readonly HubConnection connection;
        private readonly IHubProxy proxy;

        public ChatServices()
        {
            connection = new HubConnection("http://mbdserversignalr.azurewebsites.net/");
            proxy = connection.CreateHubProxy("ChatHub");
        }

        public async Task Connect()
        {
            connection.Start().Wait();
            proxy.On("GetMessage",
                (string name, string message) =>
                    OnMessageReceived(this, new ChatMessage { Message = message, Name = name }));
        }

        public async Task Send(ChatMessage message, string roomName)
        {
            Debug.WriteLine($"Connection: {connection.State}");
            await proxy.Invoke("SendMessage", message.Name, message.Message, roomName);
        }

        public async Task JoinRoom(string roomName)
        {
            await proxy.Invoke("JoinRoom", roomName);
        }

        public event EventHandler<ChatMessage> OnMessageReceived;
    }
}
