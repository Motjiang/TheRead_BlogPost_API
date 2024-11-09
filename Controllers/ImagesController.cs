using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TheRead_BlogPost_API.Models.Domains;
using TheRead_BlogPost_API.Models.DTOs;
using TheRead_BlogPost_API.Repositories.Interface;

namespace TheRead_BlogPost_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ImagesController : ControllerBase
    {
        private readonly IImageRepository _imageRepository;

        public ImagesController(IImageRepository imageRepository)
        {
            _imageRepository = imageRepository;
        }


        [HttpPost]
        public async Task<IActionResult> UploadImage([FromForm]IFormFile file, [FromForm] string fileName, [FromForm] string title)
        {
            ValidateFileUpload(file);

            if (ModelState.IsValid)
            {
              var blogImage = new BlogImage
              {
                  FileName = fileName,
                  FileExtension = Path.GetExtension(file.FileName),
                  Title = title,
                  DateCreated = DateTime.Now
              };

                blogImage = await _imageRepository.Upload(blogImage, file);

                // Domain model to DTO
                var response = new BlogImageDto
                {
                    Id = blogImage.Id,
                    FileName = blogImage.FileName,
                    FileExtension = blogImage.FileExtension,
                    Title = blogImage.Title,
                    Url = blogImage.Url,
                    DateCreated = blogImage.DateCreated
                };
                return Ok(response);
            }
            return BadRequest(ModelState);
        }

        private void ValidateFileUpload(IFormFile file)
        {
            var allowedExtensions = new string[] { ".jpg", ".jpeg", ".png", ".gif" };

            if(!allowedExtensions.Contains(Path.GetExtension(file.FileName)))
            {
                ModelState.AddModelError("file", "Unsupported file format");
            }

            if (file.Length > 10485760)
            {
                ModelState.AddModelError("file", "File size cannot be more than 10MB");
            }
        }
    }
}
