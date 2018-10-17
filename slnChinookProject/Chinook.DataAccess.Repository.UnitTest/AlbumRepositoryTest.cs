using System;
using System.Linq;
using System.Data.Entity;
using Chinook.DataAccess.Repository.Interfaces;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Chinook.Entities.Base;

namespace Chinook.DataAccess.Repository.UnitTest
{
    [TestClass]
    public class AlbumRepositoryTest
    {
        private readonly DbContext dbContext;
        private readonly IAlbumRepository albumRepository;
        private readonly IUnitOfWork unitOfWork;

        public AlbumRepositoryTest()
        {
            dbContext = new ChinookDBModel();
            albumRepository = new AlbumRepository(dbContext);
            unitOfWork = new UnitOfWork(dbContext);
        }

        [TestMethod]
        public void GetCountAlbum()
        {
            var cantidad = albumRepository.Count();
            Assert.IsTrue(cantidad > 0, "OK");
        }


        [TestMethod]
        public void GetAllAlbum()
        {
            var album = albumRepository.GetAll();
            Assert.IsTrue(album.Count() > 0, "OK");
        }

        [TestMethod]
        public void GetByidAlbum()
        {
            int idPrueba = 52;
            var album = albumRepository.GetByid(idPrueba);
            Assert.IsTrue(album.Title != "", "OK");
        }

        [TestMethod]
        public void AddAlbum()
        {
            var album = new Album();
            album.Title = "Test Album";
            album.ArtistId = 70;
            albumRepository.Add(album);
            dbContext.SaveChanges();

            Assert.IsTrue(album.AlbumId > 0, "OK");

        }

        [TestMethod]
        public void RemoveAlbum()
        {
            var album = new Album();
            album.AlbumId = 350;
            albumRepository.Remove(album);
            var registroseliminados = dbContext.SaveChanges();

            Assert.IsTrue(registroseliminados > 0, "OK");

        }

        [TestMethod]
        public void AlbunesVendidos()
        {
            var listado = unitOfWork.AlbumRepository.GetAlbunesVendidos();
            unitOfWork.Dispose();
            Assert.IsTrue(listado.Count() > 0, "OK");
        }

    }
}
