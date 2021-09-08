using Microsoft.AspNetCore.Identity;
using mIRC.Core.Interfaces;
using System;
using System.Collections.Generic;

namespace mIRC.Db.Entities
{
    public class User : IdentityUser, IAuditInfo
    {
        public DateTime CreatedOn { get; set; }
        public DateTime? ModifiedOn { get; set; }

        public ICollection<Room> Rooms { get; set; } = new HashSet<Room>();

    }
}
