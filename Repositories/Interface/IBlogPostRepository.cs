﻿using TheRead_BlogPost_API.Models.Domains;

namespace TheRead_BlogPost_API.Repositories.Interface
{
    public interface IBlogPostRepository
    {
        // Create a blog post
        Task<BlogPost> CreateAsync(BlogPost blogPost);
    }
}
