using Gravenger.Domain.Core.Models;
using System;

namespace Gravenger.Domain.Core.Dto
{
    public class NotificationDTO
    {
        public string ActorAccountUsername { get; set; }
        public string ActorAccountProfileImageFullPath { get; set; }
        public int? CardID { get; set; }
        public string CardTitle { get; set; }
        public NotificationType Type { get; set; }
        public bool IsRead { get; set; }
        public DateTimeOffset DateTimeStamp { get; set; }
    }
}
