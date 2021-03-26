using System;
using System.Threading.Tasks;
using AutoFixture;
using BLL.Contracts;
using BLL.Implementation;
using DataAccess.Contracts;
using Domain;
using Domain.Models;
using FluentAssertions;
using Moq;
using NUnit.Framework;

namespace BLL.Tests.Unit
{
    public class ArtistGetServiceTests
    {
        [Test]
        public async Task CreateAsync_ArtistValidationSucceed_CreatesAlbum()
        {
            // Arrange
            var albumUpdateModel = new AlbumUpdateModel();
            var expected = new Album();
            
            var artistGetService = new Mock<IArtistGetService>();
            artistGetService.Setup(x => x.ValidateAsync(albumUpdateModel));

            var albumDataAccess = new Mock<IAlbumDataAccess>();
            albumDataAccess.Setup(x => x.InsertAsync(albumUpdateModel)).ReturnsAsync(expected);

            var albumCreateService = new AlbumCreateService(albumDataAccess.Object, artistGetService.Object);
            
            // Act
            var result = await albumCreateService.CreateAsync(albumUpdateModel);
            
            // Assert
            result.Should().Be(expected);
        }
        
        [Test]
        public async Task CreateAsync_ArtistValidationFailed_ThrowsError()
        {
            // Arrange
            var fixture = new Fixture();
            var albumUpdateModel = new AlbumUpdateModel();
            var expected = fixture.Create<string>();
            
            var artistGetService = new Mock<IArtistGetService>();
            artistGetService
                .Setup(x => x.ValidateAsync(albumUpdateModel))
                .Throws(new InvalidOperationException(expected));

            var albumDataAccess = new Mock<IAlbumDataAccess>();

            var albumCreateService = new AlbumCreateService(albumDataAccess.Object, artistGetService.Object);
            
            // Act
            var action = new Func<Task>(() => albumCreateService.CreateAsync(albumUpdateModel));
            
            // Assert
            await action.Should().ThrowAsync<InvalidOperationException>().WithMessage(expected);
            albumDataAccess.Verify(x => x.InsertAsync(albumUpdateModel), Times.Never);
        }
    }
}