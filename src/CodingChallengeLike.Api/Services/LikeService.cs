using System;
using System.Threading.Tasks;
using CodingChallengeLike.Api.ViewModels;
using CodingChallengLike.Api.Services.Interfaces;
using CodingChallengLike.Domain.Interfaces.Repositories;

namespace CodingChallengLike.Api.Services
{
    public class LikeService : ILikeService{
        
        private readonly ILikeRepository _likeRepository;

        public LikeService(ILikeRepository likeRepository){
            _likeRepository = likeRepository;
        }

        public async Task<LikeResponseViewModel> InsertAsync(LikeRequestViewModel likeRequestViewModel){
            throw new NotImplementedException();
        }

        public async Task UpdateAsync(LikeRequestViewModel likeRequestViewModel){
            throw new NotImplementedException();
            
        }

        public async Task DeleteAsync(LikeRequestViewModel likeRequestViewModel){
            throw new NotImplementedException();
            
        }

    }
}