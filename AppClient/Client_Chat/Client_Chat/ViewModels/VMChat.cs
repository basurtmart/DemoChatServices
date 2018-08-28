using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using Client_Chat.Models;
using Client_Chat.Services;
using Xamarin.Forms;

namespace Client_Chat.ViewModels
{
    public class VMChat : VMBase
    {
        public VMChat()
        {
            Title = "ITESHU Chat";
            chatServices = DependencyService.Get<IChatServices>();
            chatServices = new ChatServices();

            Messages = new ObservableCollection<ChatMessage>();
            WriteMessage = new ChatMessage();
            
            chatServices.Connect();
            chatServices.JoinRoom(roomName);
            chatServices.OnMessageReceived += (sender, message) =>
            {
                Messages.Add(new ChatMessage {Name = message.Name, Message = message.Message});
            };

            SendMessageCommand = new Command(async () =>
            {
                IsBusy = true;
                await chatServices.Send(new ChatMessage {Name = WriteMessage.Name, Message = WriteMessage.Message},
                    roomName);
                WriteMessage.Message = "";
                IsBusy = false;
            });
        }

        private IChatServices chatServices;
        private string roomName = "SistemasRoom";

        public Command SendMessageCommand { get; set; }

        private ObservableCollection<ChatMessage> messages;

        public ObservableCollection<ChatMessage> Messages
        {
            get { return messages; }
            set
            {
                messages = value;
                OnPropertyChanged();
            }
        }

        private ChatMessage writeMessage;

        public ChatMessage WriteMessage
        {
            get { return writeMessage; }
            set
            {
                writeMessage = value;
                OnPropertyChanged();
            }
        }

    }
}
