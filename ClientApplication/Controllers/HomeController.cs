using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using System.Net.Http.Headers;


namespace ClientApplication.Controllers
{
    public class HomeController : Controller
    {
        private readonly HttpClient _httpClient;


        public HomeController(IHttpClientFactory httpClientFactory)
        {
            _httpClient = httpClientFactory.CreateClient();
        }


        [HttpGet]
        public async Task<IActionResult> Index()
        {
            try
            {
                var response = await _httpClient.GetAsync("http://fastfoodapi:8000/api/carousel");
                response.EnsureSuccessStatusCode();

                // Replaced ReadAsAsync with JSON deserialization
                var jsonString = await response.Content.ReadAsStringAsync();
                var images = JsonSerializer.Deserialize<List<string>>(jsonString);

                return View(images);
            }
            catch (Exception ex)
            {
                // Log the error
                ViewBag.Error = "Failed to load carousel images.";
                return View(new List<string>());
            }
        }


        [HttpPost]
        public async Task<IActionResult> Upload(IFormFileCollection files)
        {
            if (files == null || files.Count == 0)
            {
                TempData["UploadError"] = "Please select at least one file.";
                return RedirectToAction("Index");
            }

            using var formData = new MultipartFormDataContent();
            foreach (var file in files)
            {
                if (!file.ContentType.StartsWith("image/jpeg") && !file.ContentType.StartsWith("image/png"))
                {
                    TempData["UploadError"] = "Only JPEG and PNG files are allowed.";
                    return RedirectToAction("Index");
                }

                var streamContent = new StreamContent(file.OpenReadStream());
                streamContent.Headers.ContentType = new MediaTypeHeaderValue(file.ContentType);
                formData.Add(streamContent, "files", file.FileName);
            }

            try
            {
                var response = await _httpClient.PostAsync("http://fastfoodapi:8000/api/carousel/", formData);
                response.EnsureSuccessStatusCode();
                TempData["UploadSuccess"] = "Upload successful!";
            }
            catch (Exception ex)
            {
                // Log the error
                TempData["UploadError"] = "Upload failed. Please try again.";
            }

            return RedirectToAction("Index");
        }
    }
}
