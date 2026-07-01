using Doccure.DoctorService.Dtos.DoctorDtos;

namespace Doccure.DoctorService.Services.DoctorServices
{
    public interface IDoctorService
    {

        Task<List<ResultDoctorDto>> GetAllDoctorAsync();

        Task<GetByIdDoctorDto> GetByIdDoctorAsync(string id);

        Task CreateDoctorAsync(CreateDoctorDto dto);

        Task UpdateDoctorAsync(UpdateDoctorDto dto);

        Task DeleteDoctorAsync(string id);
    }
}
