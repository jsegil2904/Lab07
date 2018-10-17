using Chinook.DataAccess.Repository.Interfaces;
using Chinook.Entities.Base;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chinook.DataAccess.Repository
{
    public class InvoiceRepository : GenericRepository<Invoice>, IInvoiceRepository
    {
        public InvoiceRepository(DbContext pContext) : base(pContext)
        {
        }
    }
}
