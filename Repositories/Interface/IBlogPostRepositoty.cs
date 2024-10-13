using TheRead_BlogPost_API.Models.Domains;

namespace TheRead_BlogPost_API.Repositories.Interface
{
    public interface IBlogPostRepositoty
    {
        // Create a blog post
        Task<BlogPost> CreateAsync(BlogPost blogPost);
    }
}
