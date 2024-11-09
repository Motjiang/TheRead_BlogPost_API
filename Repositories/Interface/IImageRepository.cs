using TheRead_BlogPost_API.Models.Domains;

namespace TheRead_BlogPost_API.Repositories.Interface
{
    public interface IImageRepository
    {
        Task<BlogImage> Upload(BlogImage blogImage, IFormFile file);

    }
}
