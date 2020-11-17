using Bogus;
using CodingChallengeLike.Api.ViewModels;

namespace CodingChallengeLike.Unit.Tests.Mocks
{
    public static class UserMock{
        public static Faker<UserRequestViewModel> UserRequestViewModelFaker =>
            new Faker<UserRequestViewModel>()
                .CustomInstantiator(x => new UserRequestViewModel()
                    {
                        Id = x.Random.Long(1),
                        Name = x.Random.Word()
                    }
                );
        public static Faker<UserResponseViewModel> UserResponseViewModelFaker =>
            new Faker<UserResponseViewModel>()
                .CustomInstantiator(x => new UserResponseViewModel()
                    {
                        Id = x.Random.Long(1),
                        Name = x.Random.Word()
                    }
                );
    }
}