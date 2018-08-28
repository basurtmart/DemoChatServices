using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Client_Chat.Models;

namespace Client_Chat.Services
{
    public interface IChatServices
    {
        Task Connect();
        Task Send(ChatMessage message, string roomName);
        Task JoinRoom(string roomName);
        event EventHandler<ChatMessage> OnMessageReceived;
    }
}
