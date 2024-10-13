using TheRead_BlogPost_API.Data;
using TheRead_BlogPost_API.Models.Domains;
using TheRead_BlogPost_API.Repositories.Interface;

namespace TheRead_BlogPost_API.Repositories.Implementation
{
    public class BlogPostRepository : IBlogPostRepository
    {
        //independecy injection
        private readonly ApplicationDbContext _context;

        //constructor
        public BlogPostRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<BlogPost> CreateAsync(BlogPost blogPost)
        {
            await _context.BlogPosts.AddAsync(blogPost);
            await _context.SaveChangesAsync();
            return blogPost;
        }
    }
}
