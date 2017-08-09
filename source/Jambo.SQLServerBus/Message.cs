using System;
using System.Collections.Generic;
using System.Text;

namespace Jambo.SQLServerBus
{
    public class Message
    {
        public int Id { get; set; }
        public string Type { get; set; }
        public string Data { get; set; }
    }
}
