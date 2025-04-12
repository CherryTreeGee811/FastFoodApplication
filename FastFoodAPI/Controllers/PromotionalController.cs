using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.AspNetCore.Mvc;


namespace FastFoodAPI.Controllers { 

    [ApiController]
    [Route("/api")]
    public class PromotionalController : Controller {

        /// <summary>
        /// Initializes a new instance of the <see cref="PromotionalController"/> class.
        /// </summary>
        /// <param name="env">Provides information about the web hosting environment.</param>            
        public PromotionalController(IWebHostEnvironment env) {
            _env = env;
        }

        /// <summary>
        /// Returns a list of full URLs to all JPEG or PNG images in the "carouselImages" directory under wwwroot.
        /// </summary>
        /// <returns>A 200 OK response with a list of image URLs, or 404 if the directory is missing.</returns>
        [HttpGet("carousel")]
        public IActionResult GetPromoCarouselImages() {
            string imagesPath = Path.Combine(_env.WebRootPath, _imagesDir);

            if (!Directory.Exists(imagesPath)) {
                return NotFound("Images directory not found.");
            }

            List<string> imageFiles = Directory.GetFiles(imagesPath)
                .Where(file => _allowedCarouselExtensions.Any(ext =>
                    file.EndsWith(ext, StringComparison.OrdinalIgnoreCase)))
                .Select(file => Path.GetFileName(file))
                .ToList();

            string baseUrl = $"http://localhost:8000";

            List<string> carouselItems = imageFiles.Select(file => $"{baseUrl}/{_imagesDir}/{file}").ToList();

            return Ok(carouselItems);
        }

        /// <summary>
        /// Handles uploading promotional images to the server.
        /// </summary>
        /// <param name="files">A list of image files to upload. A single image is valid.</param>
        /// <returns>
        /// A 201 Created response containing URLs of the uploaded images and a count,
        /// or a 400 Bad Request if no files are provided.
        /// </returns>
        [Authorize(Roles = "Manager")]
        [HttpPost("carousel")]
        public async Task<IActionResult> UploadPromoImages(List<IFormFile> files) {

            if (files == null || files.Count == 0) {
                return BadRequest("File is missing.");
            }

            string uploadPath = Path.Combine(_env.WebRootPath, _imagesDir);

            if (!Directory.Exists(uploadPath)) {
                Directory.CreateDirectory(uploadPath);
            }

            List<string> uploaded = new();

            foreach (IFormFile file in files) {
                string fileName = Path.GetFileName(file.FileName);
                string filePath = Path.Combine(uploadPath, fileName);

                using FileStream stream = new FileStream(filePath, FileMode.Create);
                await file.CopyToAsync(stream);

                string baseUrl = $"http://localhost:8000";
                string fileUrl = $"{baseUrl}/{_imagesDir}/{fileName}";
                uploaded.Add(fileUrl);
            }

            return Created(string.Empty, new {
                uploaded,
                count = uploaded.Count,
            });
        }

        private string _imagesDir = "carouselImages";
        private string[] _allowedCarouselExtensions = { ".png", ".jpg", ".jepg" };
        private readonly IWebHostEnvironment _env;
    }
}
