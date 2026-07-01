using AutoMapper;
using Doccure.DoctorService.Dtos.DoctorDtos;
using Doccure.DoctorService.Entities;
using Doccure.DoctorService.Settings;
using MongoDB.Driver;

namespace Doccure.DoctorService.Services.DoctorServices
{
    public class DoctorService : IDoctorService
    {
        private readonly IMongoCollection<Doctor> _doctorCollection;
        private readonly IMapper _mapper;

        // Constructor - DI ile IDatabaseSettings ve IMapper otomatik gelir
        public DoctorService(IMapper mapper, IDatabaseSettings settings)
        {
            // MongoDB bağlantısı kur
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);
            _doctorCollection = database.GetCollection<Doctor>(settings.DoctorCollectionName);

            _mapper = mapper;
        }
        public async Task CreateDoctorAsync(CreateDoctorDto dto)
        {
            var entity = _mapper.Map<Doctor>(dto);  // DTO -> Entity
            await _doctorCollection.InsertOneAsync(entity);     // MongoDB'ye ekle
        }

        public async Task DeleteDoctorAsync(string id)
        {
            await _doctorCollection.DeleteOneAsync(x => x.DoctorId == id);
        }

        public async Task<List<ResultDoctorDto>> GetAllDoctorAsync()
        {
            var values = await _doctorCollection.Find(x => true).ToListAsync();
            return _mapper.Map<List<ResultDoctorDto>>(values);
        }

        public async Task<GetByIdDoctorDto> GetByIdDoctorAsync(string id)
        {
            var value = await _doctorCollection.Find<Doctor>(x => x.DoctorId == id).FirstOrDefaultAsync();
            return _mapper.Map<GetByIdDoctorDto>(value);
        }

        public async Task UpdateDoctorAsync(UpdateDoctorDto dto)
        {
            var value = _mapper.Map<Doctor>(dto);
            await _doctorCollection.FindOneAndReplaceAsync(x => x.DoctorId == dto.DoctorId, value);
        }
    }
    
}
