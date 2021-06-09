using AutoMapper;
using Backend.Controllers;
using Core.Entities;
using Core.Interfaces;
using Moq;
using NUnit.Framework;

namespace Backend.Tests.Controllers
{
    public class AddressesControllerTests
    {
        public AddressesController controller;

        [SetUp]
        public void Setup()
        {
            var mapper = new Mock<IMapper>();

            var unitOfWork = new Mock<IUnitOfWork>();

            unitOfWork.Setup(z => z.Repository<Address>().GetById(It.IsAny<int>(), null)).Returns(new Address());

            controller = new AddressesController(mapper.Object, unitOfWork.Object);
        }

        [Test]
        public void Id_LessThenOneReturn_BadReq()
        {
            var result = controller.GetAddress(1).Result;

            Assert.That(result == null);
        }
    }
}