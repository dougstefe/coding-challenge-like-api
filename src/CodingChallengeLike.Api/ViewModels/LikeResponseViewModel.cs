namespace CodingChallengeLike.Api.ViewModels
{
    public class LikeResponseViewModel{
        public long Id { get; set; }
        public bool Liked {get;set;}
        public ApplicationResponseViewModel Application {get;set;}
        public PostResponseViewModel Post {get;set;}
        public UserResponseViewModel User {get;set;}
    }
}