namespace CodingChallengeLike.Api.ViewModels
{
    public class LikeRequestViewModel{
        public long Id { get; set; }
        public bool Liked {get;set;}
        public ApplicationRequestViewModel Application {get;set;}
        public PostRequestViewModel Post {get;set;}
        public UserRequestViewModel User {get;set;}
    }
}