using Chinook.Entities.Base;
using Chinook.Entities.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chinook.DataAccess.Repository.Interfaces
{
    public interface IAlbumRepository:IGenericRepository<Album>
    {

        IEnumerable<AlbunesVendidosQuery> GetAlbunesVendidos();
    }
}
