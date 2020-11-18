namespace CodingChallengeLike.Domain.Models
{
    public class PostRequestModel{
        public string Id { get; set; }
        public UserRequestModel User { get; set; }
        public string Title { get; set; }
        public bool Liked { get; set; }
    }
}