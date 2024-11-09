using System.ComponentModel.DataAnnotations;

namespace TheRead_BlogPost_API.Models.Domains
{
    public class Category
    {
        [Key]
        public Guid Id { get; set; }
        [StringLength(150)]
        public string Name { get; set; }
        public string UrlHandle { get; set; }

        // Navigation property
        public ICollection<BlogPost> BlogPosts { get; set; }

    }
}
