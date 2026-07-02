using Doccure.ReviewService.Dtos.ReviewDtos;

namespace Doccure.ReviewService.Services.ReviewServices
{
    public interface IReviewService
    {
        Task<List<ResultReviewDto>> GetAllReviewAsync();

        Task<GetByIdReviewDto> GetByIdReviewAsync(string id);

        Task CreateReviewAsync(CreateReviewDto dto);

        Task DeleteReviewAsync(string id);
    }
}
