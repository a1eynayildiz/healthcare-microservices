using Doccure.ReviewService.Dtos.ReviewDtos;
using Doccure.ReviewService.Services.ReviewServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Doccure.ReviewService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReviewsController : ControllerBase
    {
        private readonly IReviewService _ReviewService;

        public ReviewsController(IReviewService ReviewService)
        {
            _ReviewService = ReviewService;
        }

        //  Tüm doktorları listele
        [HttpGet]
        public async Task<IActionResult> ReviewList()
        {
            var values = await _ReviewService.GetAllReviewAsync();
            return Ok(values);
        }

        //ID'ye göre doktor getir
        [HttpGet("{id}")]
        public async Task<IActionResult> GetReview(string id)
        {
            var value = await _ReviewService.GetByIdReviewAsync(id);
            return Ok(value);
        }


        [HttpPost]
        public async Task<IActionResult> CreateReview(CreateReviewDto dto)
        {
            await _ReviewService.CreateReviewAsync(dto);
            return Ok("Review added successfully.");
        }

        // ID'ye göre doktor sil
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteReview(string id)
        {
            await _ReviewService.DeleteReviewAsync(id);
            return Ok("Review deleted successfully.");
        }
    }
}
