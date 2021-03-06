﻿using LineClient.AspNetCore.Messaging.Interfaces;
using LineClient.AspNetCore.Messaging.Models;
using LineClient.AspNetCore.Messaging.Models.LineMessage;
using Newtonsoft.Json;
using System.Text;
using System.Threading.Tasks;

namespace LineClient.AspNetCore.Messaging.Implements
{
    public class LineMessagingClient : ILineMessagingClient
    {
        private readonly ILineHttpClient lineHttpClient;

        public LineMessagingClient(ILineHttpClient lineHttpClient)
        {
            this.lineHttpClient = lineHttpClient;
        }

        public async Task<LineChatRoomInfo> GetChatRoomInfoAsync(string ChatRoomUID, string LineUID)
        {
            var data = await lineHttpClient.GetRoomProfileAsync(ChatRoomUID, LineUID).ConfigureAwait(false);
            return JsonConvert.DeserializeObject<LineChatRoomInfo>(Encoding.UTF8.GetString(data));
        }

        public async Task<LineUserInfo> GetUserInfoAsync(string userId)
        {
            var data = await lineHttpClient.GetProfileAsync(userId).ConfigureAwait(false);
            return JsonConvert.DeserializeObject<LineUserInfo>(Encoding.UTF8.GetString(data));
        }

        public Task PushMessageAsync(ILineMessage lineMessage, LineUserInfo userInfo)
        {
            throw new System.NotImplementedException();
        }

        public Task PushMessageAsync(ILineMessage lineMessage, LineChatRoomInfo chatRoomInfo)
        {
            throw new System.NotImplementedException();
        }

        Task<LineChatRoomInfo> ILineMessagingClient.GetChatRoomInfoAsync(string roomId)
        {
            throw new System.NotImplementedException();
        }
    }
}
