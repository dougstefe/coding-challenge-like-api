using Bogus;
using CodingChallengeLike.Api.ViewModels;

namespace CodingChallengeLike.Unit.Tests.Mocks
{
    public static class ApplicationMock{
        public static Faker<ApplicationRequestViewModel> ApplicationRequestViewModelFaker =>
            new Faker<ApplicationRequestViewModel>()
                .CustomInstantiator(x => new ApplicationRequestViewModel()
                    {
                        Id = x.Random.Long(1),
                        Name = x.Random.Word()
                    }
                );
        public static Faker<ApplicationResponseViewModel> ApplicationResponseViewModelFaker =>
            new Faker<ApplicationResponseViewModel>()
                .CustomInstantiator(x => new ApplicationResponseViewModel()
                    {
                        Id = x.Random.Long(1),
                        Name = x.Random.Word()
                    }
                );
    }
}