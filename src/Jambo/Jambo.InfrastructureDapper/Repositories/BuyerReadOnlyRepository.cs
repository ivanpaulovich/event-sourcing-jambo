using Jambo.Domain.AggregatesModel.BuyerAggregate;
using System.Data;
using System.Text;
using Dapper;
using System.Collections.Generic;

namespace Jambo.InfrastructureDapper.Repositories
{
    public class BuyerReadOnlyRepository : IBuyerReadOnlyRepository
    {
        private readonly OrderingContext _context;
        public BuyerReadOnlyRepository(OrderingContext context)
        {
            _context = context;
        }

        public IEnumerable<Buyer> Find(string BuyerIdentityGuid)
        {
            using (IDbConnection dbConnection = _context.Connection)
            {
                StringBuilder sql = new StringBuilder();

                sql.Append(@"SELECT * FROM BUYERS");

                dbConnection.Open();

                return dbConnection.Query<Buyer>(sql.ToString(), new { Id = BuyerIdentityGuid });

            }
        }
    }
}
