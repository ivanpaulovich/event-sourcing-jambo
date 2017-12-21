using Jambo.Domain.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Jambo.Producer.Application.Commands
{
    public class CommandBase
    {
        public Header Header { get; set; }
    }
}
