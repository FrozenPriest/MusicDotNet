using System;
using System.Threading.Tasks;
using BLL.Implementation;
using DataAccess.Contracts;
using Domain.Contracts;
using FluentAssertions;
using Moq;
using NUnit.Framework;

namespace BLL.Tests.Unit
{
    [TestFixture]
    public class DeleteSongServiceTests
    {
        [Test]
        public async Task DeleteOrderFailure()
        {
            // Arrange
            var songIdentity = new Mock<ISongIdentity>();
            var songDataAccessMock = new Mock<ISongDataAccess>();

            songDataAccessMock
                .Setup(dataAccess => dataAccess.DeleteAsync(songIdentity.Object))
                .ThrowsAsync(new InvalidOperationException());
            
            var getOrderService = new SongDeleteService(songDataAccessMock.Object);
            
            // Act
            var action = new Func<Task>(() => getOrderService.DeleteAsync(songIdentity.Object));
            
            // Assert
            await action.Should().ThrowAsync<InvalidOperationException>();
            songDataAccessMock.Verify();
        }
        
        [Test]
        public async Task DeleteSongNullFailure()
        {
            // Arrange
            var songDataAccessMock = new Mock<ISongDataAccess>();

            songDataAccessMock
                .Setup(dataAccess => dataAccess.DeleteAsync(null))
                .ThrowsAsync(new ArgumentNullException());
            
            var getOrderService = new SongDeleteService(songDataAccessMock.Object);
            
            // Act
            var action = new Func<Task>(() => getOrderService.DeleteAsync(null));
            
            // Assert
            await action.Should().ThrowAsync<ArgumentNullException>();
            songDataAccessMock.Verify();
        }
    }
}