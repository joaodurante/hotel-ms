using Application;
using Application.DTOs;
using Application.Responses;
using AutoFixture;
using Domain.Entities;
using Domain.Ports;
using Moq;

namespace ApplicationTests
{
    public class Tests
    {
        GuestManager _guestManager;
        Mock<IGuestRepository> _mockRepo;
        Fixture _fixture;

        [SetUp]
        public void Setup()
        {
            _fixture = new Fixture();
            _mockRepo = new Mock<IGuestRepository>();
            _guestManager = new GuestManager(_mockRepo.Object);
        }

        [Test]
        public async Task ShouldReturnGuest()
        {
            Guest guest = _fixture.Create<Guest>();
            _mockRepo.Setup(x => x.Get(guest.Id))
                .Returns(Task.FromResult(guest));

            var res = await _guestManager.Get(guest.Id);
            Assert.IsNotNull(res);
            Assert.True(res.Success);
            Assert.That(res.Data.Id, Is.EqualTo(guest.Id));
        }

        [Test]
        public async Task ShouldReturnNotFoundWhenGuestDoesntExists()
        {
            int guestId = _fixture.Create<int>();
            _mockRepo.Setup(x => x.Get(guestId))
                .Returns(Task.FromResult<Guest>(null));

            var res = await _guestManager.Get(guestId);
            Assert.IsNotNull(res);
            Assert.False(res.Success);
            Assert.That(res.Error, Is.EqualTo(ErrorCodes.NOT_FOUND));
            Assert.IsNull(res.Data);
        }

        [Test]
        public async Task ShouldCreateGuest()
        {
            int expectedId = _fixture.Create<int>();
            _mockRepo.Setup(x => x.Create(It.IsAny<Guest>()))
                .Returns(Task.FromResult(expectedId));

            var guest = new GuestDTO
            {
                Name = "Test",
                Surname = "Test",
                Email = "test@test.com",
                IdNumber = "123",
                IdTypeCode = 0
            };

            var res = await _guestManager.Create(guest);
            Assert.IsNotNull(res);
            Assert.True(res.Success);
            Assert.That(expectedId, Is.EqualTo(res.Data.Id));
        }

        [TestCase("", "test", "test@test.com")]
        [TestCase("test", "", "test@test.com")]
        [TestCase("test", "test", "")]
        public async Task ShouldReturnMissingRequiredFieldsException(string name, string surname, string email)
        {
            _mockRepo.Setup(x => x.Create(It.IsAny<Guest>()))
                .Returns(Task.FromResult(1));

            var guest = new GuestDTO
            {
                Name = name,
                Surname = surname,
                Email = email,
                IdNumber = "123",
                IdTypeCode = 0
            };

            var res = await _guestManager.Create(guest);
            Assert.IsNotNull(res);
            Assert.False(res.Success);
            Assert.That(res.Error, Is.EqualTo(ErrorCodes.MISSING_REQUIRED_FIELDS));
        }

        [TestCase("")]
        [TestCase("test")]
        [TestCase("test@")]
        [TestCase("test.com")]
        public async Task ShouldReturnInvalidPersonEmailException(string email)
        {
            _fixture.Customize<GuestDTO>(x =>
                x.With(y => y.Email, email)
            );
            var guest = _fixture.Create<GuestDTO>();
            _mockRepo.Setup(x => x.Create(It.IsAny<Guest>()))
                .Returns(Task.FromResult(1));

            var res = await _guestManager.Create(guest);
            Assert.IsNotNull(res);
            Assert.False(res.Success);
            Assert.That(res.Error, Is.EqualTo(ErrorCodes.INVALID_PERSON_EMAIL));
        }

        [TestCase("")]
        [TestCase("1")]
        public async Task ShouldReturnInvalidPersonDocumentException(string docNumber)
        {
            _mockRepo.Setup(x => x.Create(It.IsAny<Guest>()))
                .Returns(Task.FromResult(1));

            var guest = new GuestDTO
            {
                Name = "Test",
                Surname = "Test",
                Email = "test@test.com",
                IdNumber = docNumber,
                IdTypeCode = 0
            };

            var res = await _guestManager.Create(guest);
            Assert.IsNotNull(res);
            Assert.False(res.Success);
            Assert.That(res.Error, Is.EqualTo(ErrorCodes.INVALID_PERSON_DOCUMENT));
        }
    }
}