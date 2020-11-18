using System.Threading.Tasks;
using AutoMapper;
using CodingChallengeLike.Domain.Interfaces.Identity;
using CodingChallengeLike.Domain.Models;
using CodingChallengeLike.Unit.Tests.Mocks;
using CodingChallengLike.Api.Services;
using CodingChallengLike.Domain.Interfaces.Repositories;
using Moq;
using Xunit;

namespace CodingChallengeLike.Unit.Tests.Services
{
    public class LikeServiceTest{
        private readonly Mock<IPostRepository> _postRepositoryMock;
        private readonly Mock<IUserRepository> _userRepositoryMock;
        private readonly Mock<IIdentityService> _identityService;
        private readonly Mock<IMapper> _mapper;
        public LikeServiceTest(){
            _postRepositoryMock = new Mock<IPostRepository>();
            _userRepositoryMock = new Mock<IUserRepository>();
            _identityService = new Mock<IIdentityService>();
            _mapper = new Mock<IMapper>();
        }

        [Fact]
        public async Task InsertLikeAsync_Test(){
            var postRequestViewModelMock = PostMock.PostRequestViewModelFaker.Generate();
            var postRequestModelMock = PostMock.PostRequestModelFaker.Generate();
            _mapper.Setup(x => x.Map<PostRequestModel>(postRequestViewModelMock)).Returns(postRequestModelMock);
            var service = new LikeService(
                _postRepositoryMock.Object,
                _userRepositoryMock.Object,
                _identityService.Object,
                _mapper.Object
            );

            await service.InsertAsync(postRequestViewModelMock);
        }

        [Fact]
        public async Task UpdateLikeAsync_Test(){
            var postRequestViewModelMock = PostMock.PostRequestViewModelFaker.Generate();
            var userRequestViewModelMock = UserMock.UserRequestViewModelFaker.Generate();
            var postLikedRequestViewModelFaker = PostMock.PostLikedRequestViewModelFaker.Generate();

            var service = new LikeService(
                _postRepositoryMock.Object,
                _userRepositoryMock.Object,
                _identityService.Object,
                _mapper.Object
            );

            await service.UpdateAsync(userRequestViewModelMock.Id, postRequestViewModelMock.Id, postLikedRequestViewModelFaker);
        }

        [Fact]
        public async Task DeleteLikeAsync_Test(){
            var postRequestViewModelMock = PostMock.PostRequestViewModelFaker.Generate();
            var userRequestViewModelMock = UserMock.UserRequestViewModelFaker.Generate();

            var service = new LikeService(
                _postRepositoryMock.Object,
                _userRepositoryMock.Object,
                _identityService.Object,
                _mapper.Object
            );

            await service.DeleteAsync(userRequestViewModelMock.Id, postRequestViewModelMock.Id);
        }
    }
}