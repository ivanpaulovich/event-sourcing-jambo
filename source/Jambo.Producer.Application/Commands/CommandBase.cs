using System;
using System.Collections.Generic;
using System.Text;

namespace Jambo.Producer.Application.Commands
{
    public class CommandBase
    {
        public Guid CorrelationId { get; set; }
    }
}
