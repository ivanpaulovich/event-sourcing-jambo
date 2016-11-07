using Jambo.Core.Infrastructure.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Jambo.Core.Infrastructure.Repository
{
    public interface IRoomRepository
    {
        void CreateRoom(string name);

        IEnumerable<IRoomRecord> GetAllRooms();
    }
}
