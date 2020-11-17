namespace CodingChallengeLike.Domain.Models
{
    public class LikeModel{
        public long Id { get; set; }
        public bool Liked {get;set;}
        public ApplicationModel Application {get;set;}
        public PostModel Post {get;set;}
        public UserModel User {get;set;}
    }
}