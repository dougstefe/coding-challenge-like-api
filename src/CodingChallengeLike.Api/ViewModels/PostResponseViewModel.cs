using System;

namespace CodingChallengeLike.Api.ViewModels
{
    public class PostResponseViewModel{
        /// <summary>
        /// Post ID
        /// </summary>
        public string Id { get; set; }
        /// <summary>
        /// Interaction creation date
        /// </summary>
        public DateTime CreatedDate { get; set; }
        /// <summary>
        /// Post title
        /// </summary>
        public string Title { get; set; }
        /// <summary>
        /// if the user liked
        /// </summary>
        public bool Liked { get; set; }
    }
}