using AutoMapper;
using CodingChallengeLike.Api.ViewModels;
using CodingChallengeLike.Domain.Models;
using CodingChallengeLike.Domain.Models.Services;

namespace CodingChallengeLike.Api.AutoMapper
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<PostRequestViewModel, PostRequestModel>();
            CreateMap<UserRequestViewModel, UserRequestModel>();

            CreateMap<AuthenticationRequestViewModel, AuthenticationRequestModel>();
            CreateMap<ApplicationRequestViewModel, ApplicationRequestModel>();
            CreateMap<AuthenticationResponse, ApplicationResponseViewModel>();

        }
    }
}