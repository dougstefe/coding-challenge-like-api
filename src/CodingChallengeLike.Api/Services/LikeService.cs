using System;
using System.Threading.Tasks;
using AutoMapper;
using CodingChallengeLike.Api.ViewModels;
using CodingChallengeLike.Domain.Interfaces.Identity;
using CodingChallengeLike.Domain.Models;
using CodingChallengLike.Api.Services.Interfaces;
using CodingChallengLike.Domain.Interfaces.Repositories;

namespace CodingChallengLike.Api.Services
{
    public class LikeService : ILikeService{
        
        private readonly IPostRepository _postRepository;
        private readonly IUserRepository _userRepository;
        private readonly IIdentityService _identityService;
        private readonly IMapper _mapper;

        public LikeService(IPostRepository postRepository, IUserRepository userRepository, IIdentityService identityService, IMapper mapper)
        {
            _postRepository = postRepository;
            _userRepository = userRepository;
            _identityService = identityService;
            _mapper = mapper;
        }

        public async Task<PostResponseViewModel> InsertAsync(PostRequestViewModel postViewModel){

            var postRequestModel = _mapper.Map<PostRequestModel>(postViewModel);
            var applicationId = _identityService.GetApplicationId();

            var postInsertDapper = new PostInsertDapper(){
                    Id = postRequestModel.Id,
                    ApplicationId = applicationId,
                    UserId = postRequestModel.User.Id,
                    CreatedDate = DateTime.Now,
                    Title = postRequestModel.Title,
                    Liked = postRequestModel.Liked
                };

            Task.WaitAll(new Task[2]{
                _userRepository.InsertAsync(new UserInsertDapper(){
                    Id = postRequestModel.User.Id,
                    ApplicationId = applicationId,
                    Name = postRequestModel.User.Name
                }),
                _postRepository.InsertAsync(postInsertDapper)
            });
            
            return new PostResponseViewModel(){
                Id = postInsertDapper.Id,
                CreatedDate = postInsertDapper.CreatedDate,
                Title = postInsertDapper.Title,
                Liked = postInsertDapper.Liked
            };
        }
        public async Task<PostResponseViewModel> GetAsync(string userId, string postId){
            var postDapper = await _postRepository.GetAsync(_identityService.GetApplicationId(), userId, postId);
            if(string.IsNullOrEmpty(postDapper?.Id)){
                return null;
            }
            return new PostResponseViewModel(){
                Id = postDapper.Id,
                CreatedDate = postDapper.CreatedDate,
                Title = postDapper.Title,
                Liked = postDapper.Liked
            };
        }

        public async Task UpdateAsync(string userId, string postId, PostLikedRequestViewModel postLikedRequestViewModel){
            await _postRepository.UpdateAsync(_identityService.GetApplicationId(), userId, postId, postLikedRequestViewModel.Liked);
        }

        public async Task DeleteAsync(string userId, string postId){
            await _postRepository.DeleteAsync(_identityService.GetApplicationId(), userId, postId);
        }

    }
}