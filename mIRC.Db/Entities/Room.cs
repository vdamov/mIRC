using mIRC.Core.Entities;
using mIRC.Core.Enums;
using System.Collections.Generic;

namespace mIRC.Db.Entities
{
    public class Room : BaseModel<string>
    {
        public string Name { get; set; }
        public RoomType Type { get; set; }
        public ICollection<User> Users { get; set; } = new HashSet<User>();
        public ICollection<Message> Messages { get; set; } = new HashSet<Message>();
    }
}
