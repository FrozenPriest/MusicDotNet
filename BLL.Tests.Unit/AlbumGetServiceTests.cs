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
    public class AlbumGetServiceTests
    {
        [Test]
        public async Task CreateAsync_AlbumValidationSucceed_CreatesSong()
        {
            // Arrange
            var songUpdateModel = new SongUpdateModel();
            var expected = new Song();
            
            var albumGetService = new Mock<IAlbumGetService>();
            albumGetService.Setup(x => x.ValidateAsync(songUpdateModel));

            var songDataAccess = new Mock<ISongDataAccess>();
            songDataAccess.Setup(x => x.InsertAsync(songUpdateModel)).ReturnsAsync(expected);

            var songCreateService = new SongCreateService(songDataAccess.Object, albumGetService.Object);
            
            // Act
            var result = await songCreateService.CreateAsync(songUpdateModel);
            
            // Assert
            result.Should().Be(expected);
        }
        
        [Test]
        public async Task CreateAsync_DepartmentValidationFailed_ThrowsError()
        {
            // Arrange
            var fixture = new Fixture();
            var songUpdateModel = new SongUpdateModel();
            var expected = fixture.Create<string>();
            
            var albumGetService = new Mock<IAlbumGetService>();
            albumGetService
                .Setup(x => x.ValidateAsync(songUpdateModel))
                .Throws(new InvalidOperationException(expected));

            var songDataAccess = new Mock<ISongDataAccess>();

            var songCreateService = new SongCreateService(songDataAccess.Object, albumGetService.Object);
            
            // Act
            var action = new Func<Task>(() => songCreateService.CreateAsync(songUpdateModel));
            
            // Assert
            await action.Should().ThrowAsync<InvalidOperationException>().WithMessage(expected);
            songDataAccess.Verify(x => x.InsertAsync(songUpdateModel), Times.Never);
        }
    }
}