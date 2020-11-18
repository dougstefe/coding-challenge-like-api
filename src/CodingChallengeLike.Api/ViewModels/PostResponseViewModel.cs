using System;

namespace CodingChallengeLike.Api.ViewModels
{
    public class PostResponseViewModel{
        public string Id { get; set; }
        public DateTime CreatedDate { get; set; }
        public string Title { get; set; }
        public bool Liked { get; set; }
    }
}