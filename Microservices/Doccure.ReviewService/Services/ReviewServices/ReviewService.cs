using AutoMapper;
using Doccure.ReviewService.Dtos.ReviewDtos;
using Doccure.ReviewService.Entities;
using Doccure.ReviewService.Settings;
using Microsoft.AspNetCore.Mvc.ViewEngines;
using MongoDB.Driver;
using System.Numerics;

namespace Doccure.ReviewService.Services.ReviewServices
{
    public class ReviewService : IReviewService
    {
        private readonly IMongoCollection<Review> _reviewCollection;
        private readonly IMapper _mapper;

        // Constructor - DI ile IDatabaseSettings ve IMapper otomatik gelir
        public ReviewService(IMapper mapper, IDatabaseSettings settings)
        {
            // MongoDB bağlantısı kur
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);
            _reviewCollection = database.GetCollection<Review>(settings.ReviewCollectionName);

            _mapper = mapper;
        }
        public async Task CreateReviewAsync(CreateReviewDto dto)
        {
            var entity = _mapper.Map<Review>(dto);  // DTO -> Entity
            await _reviewCollection.InsertOneAsync(entity);     // MongoDB'ye ekle
        }

        public async Task DeleteReviewAsync(string id)
        {
            await _reviewCollection.DeleteOneAsync(x => x.ReviewId == id);
        }

        public async Task<List<ResultReviewDto>> GetAllReviewAsync()
        {
            var values = await _reviewCollection.Find(x => true).ToListAsync();
            return _mapper.Map<List<ResultReviewDto>>(values);
        }

        public async Task<GetByIdReviewDto> GetByIdReviewAsync(string id)
        {
            var value = await _reviewCollection.Find(x => x.ReviewId == id).FirstOrDefaultAsync();
            return _mapper.Map<GetByIdReviewDto>(value);
        }
    }
}
