﻿namespace TheRead_BlogPost_API.Models.DTOs
{
    public class UpdateBlogPostRequestDto
    {
        public string Title { get; set; }
        public string ShortDescription { get; set; }
        public string Content { get; set; }
        public string FeaturedImageUrl { get; set; }
        public string UrlHandle { get; set; }
        public DateTime PublishDate { get; set; }
        public string Author { get; set; }
        public bool IsVisible { get; set; }

        //accepts a list of category ids
        public List<Guid> Categories { get; set; } = new List<Guid>();
    }
}
