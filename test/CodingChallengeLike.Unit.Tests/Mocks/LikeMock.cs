using Bogus;
using CodingChallengeLike.Api.ViewModels;

namespace CodingChallengeLike.Unit.Tests.Mocks
{
    public static class LikeMock{
        public static Faker<LikeRequestViewModel> LikeRequestViewModelFaker =>
            new Faker<LikeRequestViewModel>()
                .CustomInstantiator(x => new LikeRequestViewModel()
                    {
                        Id = x.Random.Long(1),
                        Liked = x.Random.Bool(),
                        Application = ApplicationMock.ApplicationRequestViewModelFaker,
                        Post = PostMock.PostRequestViewModelFaker,
                        User = UserMock.UserRequestViewModelFaker
                    }
                );
        public static Faker<LikeResponseViewModel> LikeResponseViewModelFaker =>
            new Faker<LikeResponseViewModel>()
                .CustomInstantiator(x => new LikeResponseViewModel()
                    {
                        Id = x.Random.Long(1),
                        Liked = x.Random.Bool(),
                        Application = ApplicationMock.ApplicationResponseViewModelFaker,
                        Post = PostMock.PostResponseViewModelFaker,
                        User = UserMock.UserResponseViewModelFaker
                    }
                );
    }
}