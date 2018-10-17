using Chinook.DataAccess.Repository.Interfaces;
using Chinook.Entities.Base;
using Chinook.Entities.Queries;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chinook.DataAccess.Repository
{
    public class AlbumRepository:
        GenericRepository<Album>,IAlbumRepository
    {
        public AlbumRepository(DbContext context) : base(context)
        {
        }

        public IEnumerable<AlbunesVendidosQuery> GetAlbunesVendidos()
        {
            return this.context.Database.SqlQuery<AlbunesVendidosQuery>
                ("usp_getAlbunesVendidos").ToList();
        }
    }
}
