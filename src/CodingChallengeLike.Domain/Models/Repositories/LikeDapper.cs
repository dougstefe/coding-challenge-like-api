namespace CodingChallengeLike.Domain.Models
{
    public class LikeDapper{
        public long Id { get; set; }
        public bool Liked {get;set;}
        public ApplicationDapper Application {get;set;}
        public PostDapper Post {get;set;}
        public UserDapper User {get;set;}
    }
}