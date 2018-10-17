
using Chinook.DataAccess.Repository.Interfaces;
using Chinook.Entities.Base;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chinook.DataAccess.Repository
{
    public class ArtistRepository :
        GenericRepository<Artist>,IArtistRepository
    {
        public ArtistRepository(DbContext context):base(context)
        {
        }

        public IEnumerable<Artist> GetListByName(string name)
        {
            return ((ChinookDBModel)context).Artist
                .Where(item => item.Name.Contains(name)).ToList();
        }

        public IEnumerable<Artist> GetListByNameStore(string name)
        {
            return context.Database.SqlQuery<Artist>("usp_GetListByName @Name",
                    new SqlParameter("@Name", name)
                ).ToList();
        }
    }
}
