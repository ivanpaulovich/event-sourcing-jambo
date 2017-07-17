using System;
using System.Collections.Generic;
using System.Text;

namespace Jambo.Domain.AggregatesModel.BlogAggregate
{
    public interface IBlogWriteOnlyRepository
    {
        Blog Add(Blog buyer);
        Blog Update(Blog buyer);
    }
}
