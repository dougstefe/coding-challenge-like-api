using Bogus;
using CodingChallengeLike.Api.ViewModels;

namespace CodingChallengeLike.Unit.Tests.Mocks
{
    public static class PostMock{
        public static Faker<PostRequestViewModel> PostRequestViewModelFaker =>
            new Faker<PostRequestViewModel>()
                .CustomInstantiator(x => new PostRequestViewModel()
                    {
                        Id = x.Random.Long(1),
                        Name = x.Random.Word()
                    }
                );
        public static Faker<PostResponseViewModel> PostResponseViewModelFaker =>
            new Faker<PostResponseViewModel>()
                .CustomInstantiator(x => new PostResponseViewModel()
                    {
                        Id = x.Random.Long(1),
                        Name = x.Random.Word()
                    }
                );
    }
}