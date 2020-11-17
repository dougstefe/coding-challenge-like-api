using Bogus;
using CodingChallengeLike.Api.ViewModels;
using CodingChallengeLike.Domain.Models;

namespace CodingChallengeLike.Unit.Tests.Mocks
{
    public static class PostMock{
        public static Faker<PostRequestViewModel> PostRequestViewModelFaker =>
            new Faker<PostRequestViewModel>()
                .CustomInstantiator(x => new PostRequestViewModel()
                    {
                        Id = x.Random.Guid().ToString(),
                        User = UserMock.UserRequestViewModelFaker,
                        Title = x.Random.Words(),
                        Liked = x.Random.Bool()
                    }
                );
        public static Faker<PostLikedRequestViewModel> PostLikedRequestViewModelFaker =>
            new Faker<PostLikedRequestViewModel>()
                .CustomInstantiator(x => new PostLikedRequestViewModel()
                    {
                        Liked = x.Random.Bool()
                    }
                );
        public static Faker<PostResponseViewModel> PostResponseViewModelFaker =>
            new Faker<PostResponseViewModel>()
                .CustomInstantiator(x => new PostResponseViewModel()
                    {
                        Id = x.Random.Guid().ToString(),
                        CreatedDate = x.Date.Past(),
                        Title = x.Random.Word(),
                        Liked = x.Random.Bool()
                    }
                );

        
        public static Faker<PostRequestModel> PostRequestModelFaker =>
            new Faker<PostRequestModel>()
                .CustomInstantiator(x => new PostRequestModel()
                    {
                        Id = x.Random.Guid().ToString(),
                        User = UserMock.UserRequestModelFaker,
                        Title = x.Random.Words(),
                        Liked = x.Random.Bool()
                    }
                );
    }
}