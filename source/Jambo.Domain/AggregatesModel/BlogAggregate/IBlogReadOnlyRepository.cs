using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Jambo.Domain.AggregatesModel.BlogAggregate
{
    public interface IBlogReadOnlyRepository
    {
        Blog FindAsync(int id);
    }
}
