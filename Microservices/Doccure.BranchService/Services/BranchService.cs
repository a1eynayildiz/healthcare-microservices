using AutoMapper;
using Doccure.BranchService.Dtos.BranchDtos;
using Doccure.BranchService.Entities;
using Doccure.BranchService.Settings;
using MongoDB.Driver;

namespace Doccure.BranchService.Services
{
    public class BranchService : IBranchService
    {
        // Bağımlılıklar (dependencies)
        private readonly IMongoCollection<Branch> _branchCollection;
        private readonly IMapper _mapper;

        public BranchService(IMapper mapper, IDatabaseSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);//MongoDb'ye bağlanan istemci(bağlantı adresi)
            var database = client.GetDatabase(settings.DatabaseName);//Veritabanına ulaşma işlemini clientla yapıyoruz
            _branchCollection = database.GetCollection<Branch>(settings.BranchCollectionName);//yukarıda aslında tanımladığımız collection ismi ile branch collection'ına ulaşıyoruz
            _mapper = mapper;
        }

        public async Task CreateBranchAsync(CreateBranchDto dto)
        {
            var value = _mapper.Map<Branch>(dto);
            await _branchCollection.InsertOneAsync(value);
        }

        public async Task DeleteBranchAsync(string id)
        {
            await _branchCollection.DeleteOneAsync(x => x.BranchId == id);
        }

        public async Task<List<ResultBranchDto>> GetAllBranchAsync()//Tüm branşları getir, frontend'e gönder
        {
            var values = await _branchCollection.Find(x => true).ToListAsync();
            return _mapper.Map<List<ResultBranchDto>>(values);

        }

        public async Task<GetBranchByIdDto> GetByIdBranchAsync(string id)
        {
            var value = await _branchCollection.FindAsync(x => x.BranchId == id);
            return _mapper.Map<GetBranchByIdDto>(value);
        }

        public async Task UpdateBranchAsync(UpdateBranchDto dto)
        {
            var value = _mapper.Map<Branch>(dto);
            await _branchCollection.FindOneAndReplaceAsync(x => x.BranchId == dto.BranchId, value);
        }
    }
}
