namespace CodingChallengeLike.Domain.Interfaces.Identity
{
    public interface IIdentityService
    {
        string GetScope();
        string GetApplicationId();
    }
}