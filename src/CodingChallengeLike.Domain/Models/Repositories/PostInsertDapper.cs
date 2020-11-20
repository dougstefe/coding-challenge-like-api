using System;

namespace CodingChallengeLike.Domain.Models
{
    public class PostInsertDapper{
        public string Id { get; set; }
        public string ApplicationId { get;set; }
        public string UserId { get;set; }
        public DateTime CreatedDate { get; set; }
        public string Title { get;set; }
        public bool Liked { get;set; }
    }
}