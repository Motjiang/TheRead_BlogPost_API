using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TheRead_BlogPost_API.Models.Domains;
using TheRead_BlogPost_API.Models.DTOs;
using TheRead_BlogPost_API.Repositories.Implementation;
using TheRead_BlogPost_API.Repositories.Interface;

namespace TheRead_BlogPost_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BlogPostsController : ControllerBase
    {
        //DI (Dependency Injection) is used to inject the IBlogPostRepository into the constructor
        private readonly IBlogPostRepository _blogPostRepository;

        public BlogPostsController(IBlogPostRepository blogPostRepository)
        {
            _blogPostRepository = blogPostRepository;
        }


        //create the httppost method for creating a blog post
        [HttpPost]
        public async Task<IActionResult> CreateBlogPost(CreateBlogPostRequestDto request)
        {
            // Map the DTO to a domain model
            var blogPost = new BlogPost
            {
                Title = request.Title,
                ShortDescription = request.ShortDescription,
                Content = request.Content,
                FeaturedImageUrl = request.FeaturedImageUrl,
                UrlHandle = request.UrlHandle,
                PublishDate = request.PublishDate,
                Author = request.Author,
                IsVisible = request.IsVisible
            };

            // Save the blog post
            blogPost = await _blogPostRepository.CreateAsync(blogPost);

            // Domain model to DTO
            var response = new BlogPostDto
            {
                Id = blogPost.Id,
                Title = blogPost.Title,
                ShortDescription = blogPost.ShortDescription,
                Content = blogPost.Content,
                FeaturedImageUrl = blogPost.FeaturedImageUrl,
                UrlHandle = blogPost.UrlHandle,
                PublishDate = blogPost.PublishDate,
                Author = blogPost.Author,
                IsVisible = blogPost.IsVisible
            };

            return Ok(response);
        }
    }
}
