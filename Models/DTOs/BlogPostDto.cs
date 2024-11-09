namespace TheRead_BlogPost_API.Models.DTOs
{
    public class BlogPostDto
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string ShortDescription { get; set; }
        public string Content { get; set; }
        public string FeaturedImageUrl { get; set; }
        public string UrlHandle { get; set; }
        public DateTime PublishDate { get; set; }
        public string Author { get; set; }
        public bool IsVisible { get; set; }

        //accepts category ids from the CategoryDto
        public List<CategoryDto> Categories { get; set; } = new List<CategoryDto>();
    }
}
