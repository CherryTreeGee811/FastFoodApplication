using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.AspNetCore.Mvc;

namespace TrainingPromotionalContentFiefdomAPI.Controllers {

    [ApiController()]
    public class PromotionalController : Controller {

        /// <summary>
        /// Initializes a new instance of the <see cref="PromotionalController"/> class.
        /// </summary>
        /// <param name="env">Provides information about the web hosting environment.</param>            
        public PromotionalController(IWebHostEnvironment env) {
            _env = env;
        }

        /// <summary>
        /// Returns a list of full URLs to all PNG images in the "images" directory under wwwroot.
        /// </summary>
        /// <returns>A 200 OK response with a list of image URLs, or 404 if the directory is missing.</returns>
        [HttpGet("/carousel")]
        public IActionResult Index() {
            // Get the path to the images directory
            string imagesDir = "carouselImages";
            string imagesPath = Path.Combine(_env.WebRootPath, imagesDir);

            if (!Directory.Exists(imagesPath)) {
                return NotFound("Images directory not found.");
            }

            List<string> imageFiles = Directory.GetFiles(imagesPath)
                .Where(file => file.EndsWith(".png"))
                .Select(file => Path.GetFileName(file))
                .ToList();

            string baseUrl = $"{Request.Scheme}://{Request.Host}";

            List<string> carouselItems = imageFiles.Select(file => $"{baseUrl}/{imagesDir}/{file}").ToList();

            return Ok(carouselItems);
        }    

        private readonly IWebHostEnvironment _env;
    }
}
