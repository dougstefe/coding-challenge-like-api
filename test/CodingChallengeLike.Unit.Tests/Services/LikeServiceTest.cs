using System.Threading.Tasks;
using CodingChallengeLike.Unit.Tests.Mocks;
using CodingChallengLike.Api.Services;
using CodingChallengLike.Domain.Interfaces.Repositories;
using Moq;
using Xunit;

namespace CodingChallengeLike.Unit.Tests.Services
{
    public class LikeServiceTest{
        private readonly Mock<ILikeRepository> _likeRepositoryMock;
        public LikeServiceTest(){
            _likeRepositoryMock = new Mock<ILikeRepository>();
        }

        [Fact]
        public async Task InsertLikeAsync_Test(){
            var likeRequestViewModelMock = LikeMock.LikeRequestViewModelFaker.Generate();

            var service = new LikeService(_likeRepositoryMock.Object);

            await service.InsertAsync(likeRequestViewModelMock);
        }

        [Fact]
        public async Task UpdateLikeAsync_Test(){
            var likeRequestViewModelMock = LikeMock.LikeRequestViewModelFaker.Generate();

            var service = new LikeService(_likeRepositoryMock.Object);

            await service.UpdateAsync(likeRequestViewModelMock);
        }

        [Fact]
        public async Task DeleteLikeAsync_Test(){
            var likeRequestViewModelMock = LikeMock.LikeRequestViewModelFaker.Generate();

            var service = new LikeService(_likeRepositoryMock.Object);

            await service.DeleteAsync(likeRequestViewModelMock);
        }
    }
}