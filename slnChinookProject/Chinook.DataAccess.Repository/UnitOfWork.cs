using Chinook.DataAccess.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chinook.DataAccess.Repository
{
    public class UnitOfWork : IUnitOfWork
    {

        private readonly DbContext _context;

        public IAlbumRepository AlbumRepository { get; private set; }

        public IArtistRepository ArtistRepository { get; private set; }

        public IInvoiceRepository InvoiceRepository { get; private set; }

        public UnitOfWork(DbContext context)
        {
            _context = context;
            AlbumRepository = new AlbumRepository(_context);
            ArtistRepository = new ArtistRepository(_context);
            InvoiceRepository = new InvoiceRepository(_context);
        }

        public int Complete()
        {
            return _context.SaveChanges();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
