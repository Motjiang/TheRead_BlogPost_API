using Microsoft.EntityFrameworkCore;
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

        public async Task<IEnumerable<BlogPost>> GetAllAsync()
        {
            return await _context.BlogPosts.Include(c => c.Categories).ToListAsync();
        }

        public async Task<BlogPost> GetByIdAsync(Guid id)
        {
            return await _context.BlogPosts.Include(c => c.Categories).FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<BlogPost> GetByUrlHandleAsync(string urlHandle)
        {
            return await _context.BlogPosts.Include(c => c.Categories).FirstOrDefaultAsync(x => x.UrlHandle == urlHandle);
        }

        public async Task<BlogPost> UpdateAsync(BlogPost blogPost)
        {
           var existingBlogPost = await _context.BlogPosts.Include(c => c.Categories).FirstOrDefaultAsync(x => x.Id == blogPost.Id);
            if(existingBlogPost == null)
            {
                return null;
            }

            //update the blog post
            _context.Entry(existingBlogPost).CurrentValues.SetValues(blogPost);

            //update the categories
            existingBlogPost.Categories = blogPost.Categories;

            await _context.SaveChangesAsync();
            return blogPost;


        }

        public async Task<BlogPost> DeleteAsync(Guid id)
        {
            var blogPost = await _context.BlogPosts.FirstOrDefaultAsync(x => x.Id == id);
            if (blogPost == null)
            {
                return null;
            }

            _context.BlogPosts.Remove(blogPost);
            await _context.SaveChangesAsync();
            return blogPost;
        }
    }
}
