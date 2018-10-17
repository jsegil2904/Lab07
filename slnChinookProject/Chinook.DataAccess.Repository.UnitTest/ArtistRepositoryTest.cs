using System;
using System.Data.Entity;
using Chinook.DataAccess.Repository.Interfaces;
using Chinook.Entities.Base;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;

namespace Chinook.DataAccess.Repository.UnitTest
{
    [TestClass]
    public class ArtistRepositoryTest
    {
        private readonly DbContext dbContext;
        private readonly IArtistRepository artistRepository;
        private readonly IUnitOfWork unitOfWork;

        public ArtistRepositoryTest()
        {
            dbContext = new ChinookDBModel();
            artistRepository = new ArtistRepository(dbContext);
            unitOfWork = new UnitOfWork(dbContext);
        }

        [TestMethod]
        public void GetCount()
        {
            var cantidad = artistRepository.Count();

            Assert.IsTrue(cantidad>0,"OK");

        }

        [TestMethod]
        public void GetCountUW()
        {
            var cantidad = artistRepository.Count();

            Assert.IsTrue(cantidad > 0, "OK");

        }

        [TestMethod]
        public void Add()
        {
            var artist = new Artist();
            artist.Name = "Test";
            artistRepository.Add(artist);
            dbContext.SaveChanges();

            Assert.IsTrue(artist.ArtistId > 0, "OK");

        }

        [TestMethod]
        public void AddUW()
        {
            var artist = new Artist();
            artist.Name = "Test";
            unitOfWork.ArtistRepository.Add(artist);
            unitOfWork.Complete();
            unitOfWork.Dispose();

            Assert.IsTrue(artist.ArtistId > 0, "OK");

        }

        [TestMethod]
        public void GetAll()
        {
            var cantidad = artistRepository.GetAll().Count();

            Assert.IsTrue(cantidad > 0, "OK");

        }
        [TestMethod]
        public void Remove()
        {
            var artist = new Artist();
            artist.ArtistId = 285;
            artistRepository.Remove(artist);
            var registrosEliminados = dbContext.SaveChanges();

            Assert.IsTrue(registrosEliminados > 0, "OK");

        }

        [TestMethod]
        public void GetByName()
        {
            var cantidad = artistRepository.GetListByName("Black").Count();

            Assert.IsTrue(cantidad == 5, "OK");

        }

        [TestMethod]
        public void GetByNameStore()
        {
            var cantidad = artistRepository.GetListByNameStore("%Black%").Count();

            Assert.IsTrue(cantidad == 5, "OK");

        }


    }
}
