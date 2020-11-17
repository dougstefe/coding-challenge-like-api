using AutoMapper;
using CodingChallengeLike.Api.ViewModels;
using CodingChallengeLike.Domain.Models;

namespace CodingChallengeLike.Api.AutoMapper
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<PostRequestViewModel, PostRequestModel>();
            CreateMap<UserRequestViewModel, UserRequestModel>();
        }
    }
}