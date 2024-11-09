using TheRead_BlogPost_API.Data;
using TheRead_BlogPost_API.Models.Domains;
using TheRead_BlogPost_API.Repositories.Interface;

namespace TheRead_BlogPost_API.Repositories.Implementation
{
    public class ImageRepository : IImageRepository
    {
        private readonly IWebHostEnvironment _hostingEnvironment;
        private readonly ApplicationDbContext _context;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public ImageRepository(IWebHostEnvironment hostingEnvironment, ApplicationDbContext context, IHttpContextAccessor httpContextAccessor)
        {
            _hostingEnvironment = hostingEnvironment;
            _context = context;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task<BlogImage> Upload(BlogImage blogImage, IFormFile file)
        {
            var localPath = Path.Combine(_hostingEnvironment.ContentRootPath, "Images", $"{blogImage.FileName}{blogImage.FileExtension}");

            using (var stream = new FileStream(localPath, FileMode.Create))
            {
                await file.CopyToAsync(stream);
            }

            // Save the image to the database
            var httpRequest = _httpContextAccessor.HttpContext.Request;
            var urlPath = $"{httpRequest.Scheme}://{httpRequest.Host}{httpRequest.PathBase}/Images/{blogImage.FileName}{blogImage.FileExtension}";

            blogImage.Url = urlPath;

            await _context.BlogImages.AddAsync(blogImage);
            await _context.SaveChangesAsync();

            return blogImage;
        }
    }
}
