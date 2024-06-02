using Microsoft.AspNetCore.SignalR;
using ShopOnline.Hiep.Application.Common.Interfaces;
using ShopOnline.Hiep.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopOnline.Hiep.Application.Hubs
{
    public class ChatHub :Hub
    {
        private readonly IApplicationDbContext _context;

        public ChatHub(IApplicationDbContext context) => _context = context;

        public async Task JoinChar(Messages conn)
        {
            await Clients.All.SendAsync("ReceiveMessage", "admin", $"{conn.UserId} HashCode Joined");

        }
        
        //public async Task JoinSpecificChatRoom(Messages conn)
        //{
        //    await Groups.AddToGroupAsync(Context.ConnectionId, conn.UserId);

        //    _context.Messages[Context.ConnectionId]= conn;

        //    await Clients.Group(conn.UserId).SendAsync("ReceiveSpecificMessage",  conn.UserId, $" has joined {conn.ChatRoom}");
        //}

        //public async Task SendMessage(string msg)
        //{
        //    if(_context.Messages.TryGetValue(Context.ConnectionId,out UserConnection conn))
        //    {
        //        await Clients.Group(conn.ChatRoom)
        //            .SendAsync("ReceiveSpecificMessage",conn.Username,msg);
        //    }
        //}
    }

}
