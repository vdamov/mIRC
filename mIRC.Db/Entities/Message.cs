using mIRC.Core.Entities;
using System.ComponentModel.DataAnnotations;

namespace mIRC.Db.Entities
{
    public class Message : BaseModel<string>
    {
        [Required(AllowEmptyStrings = false)]
        [MaxLength(500)]
        public string Text { get; set; }

        public string UserId { get; set; }
        public User User { get; set; }
        public string RoomId { get; set; }
        public Room Room { get; set; }
    }
}
