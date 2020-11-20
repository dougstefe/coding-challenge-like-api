using Bogus;
using CodingChallengeLike.Api.ViewModels;
using CodingChallengeLike.Domain.Models;

namespace CodingChallengeLike.Unit.Tests.Mocks
{
    public static class UserMock{
        public static Faker<UserRequestViewModel> UserRequestViewModelFaker =>
            new Faker<UserRequestViewModel>()
                .CustomInstantiator(x => new UserRequestViewModel()
                    {
                        Id = x.Random.Guid().ToString(),
                        Name = x.Random.Word()
                    }
                );
        public static Faker<UserRequestModel> UserRequestModelFaker =>
            new Faker<UserRequestModel>()
                .CustomInstantiator(x => new UserRequestModel()
                    {
                        Id = x.Random.Guid().ToString(),
                        Name = x.Random.Word()
                    }
                );
    }
}