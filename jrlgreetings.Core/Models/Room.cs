using System;
using System.Collections.Generic;
using System.Text;

namespace jrlgreetings.Core.Models
{
    public class Room
    {
        public int RoomNo { get; set; }
        public string Description { get; set; }
        public string ContentText { get; set; }
        public bool Completed { get; set; } = false;
    }
}
