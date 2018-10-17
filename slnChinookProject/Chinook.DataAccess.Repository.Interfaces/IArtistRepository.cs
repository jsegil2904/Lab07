using Chinook.Entities.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chinook.DataAccess.Repository.Interfaces
{
    public interface IArtistRepository: IGenericRepository<Artist>
    {
        IEnumerable<Artist> GetListByName(string name);

        IEnumerable<Artist> GetListByNameStore(string name);
    }
}
