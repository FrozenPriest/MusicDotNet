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
    public class SongCreateServiceTests
    {
        [Test]
        public async Task CreateAsyncSuccessful()
        {
            var song = new SongUpdateModel();
            var expected = new Song();

            var albumGetService = new Mock<IAlbumGetService>();
            albumGetService.Setup(x => x.ValidateAsync(song));

            var songDataAccess = new Mock<ISongDataAccess>();
            songDataAccess.Setup(x => x.InsertAsync(song)).ReturnsAsync(expected);

            var songCreateService = new SongCreateService(songDataAccess.Object, albumGetService.Object);

            var result = await songCreateService.CreateAsync(song);

            result.Should().Be(expected);
        }

        [Test]
        public async Task CreateAsyncFailed()
        {
            var fixture = new Fixture();
            var song = new SongUpdateModel();
            var expected = fixture.Create<string>();

            var albumGetService = new Mock<IAlbumGetService>();
            albumGetService
                .Setup(x => x.ValidateAsync(song))
                .Throws(new InvalidOperationException(expected));

            var songDataAccess = new Mock<ISongDataAccess>();

            var songCreateService = new SongCreateService(songDataAccess.Object, albumGetService.Object);

            var action = new Func<Task>(() => songCreateService.CreateAsync(song));

            await action.Should().ThrowAsync<InvalidOperationException>().WithMessage(expected);
            songDataAccess.Verify(x => x.InsertAsync(song), Times.Never);
        }
    }
}