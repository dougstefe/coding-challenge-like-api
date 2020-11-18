using System;

namespace CodingChallengeLike.Domain.Models
{
    public class PostDapper{
        public string Id { get; set; }
        public DateTime CreatedDate { get; set; }
        public string Title { get; set; }
        public bool Liked { get; set; }
    }
}