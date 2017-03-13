using Dapper;
using Jambo.Core.Interfaces.Entities;
using Jambo.Core.Interfaces.Repositories;
using Jambo.Infrastructure.Dapper.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace Jambo.Infrastructure.Dapper.Repositories
{
    public class LoteReadOnlyRepository : RepositoryBase, ILoteReadOnlyRepository
    {
        public LoteReadOnlyRepository(
            IRepositorySettings repositorySettings)
            : base(repositorySettings)
        {
        }

        public ILote Consultar(Guid idLote)
        {
            using (IDbConnection dbConnection = Connection)
            {
                string sQuery =
                    @"SELECT * FROM Lotes
                    WHERE Id=@IdLote";

                dbConnection.Open();

                return dbConnection.Query<Lote>(
                    sQuery,
                    new { IdLote = idLote }).FirstOrDefault();
            }
        }

        public IEnumerable<ILote> Listar()
        {
            throw new NotImplementedException();
        }
    }
}
