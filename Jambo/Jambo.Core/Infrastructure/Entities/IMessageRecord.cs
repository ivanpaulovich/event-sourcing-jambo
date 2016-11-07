using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Jambo.Core.Infrastructure.Entities
{
    public interface IMessageRecord
    {
        int RoomID { get; set; }
        string Text { get; set; }
        string AuthorName { get; set; }
    }
}
