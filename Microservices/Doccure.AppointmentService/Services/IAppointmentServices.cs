using Doccure.AppointmentService.Dtos.AppointmentDtos;

namespace Doccure.AppointmentService.Services
{
    public interface IAppointmentServices
    {
        Task<List<ResultAppointmentDto>> GetAllAsync();
        Task<GetAppointmentByIdDto> GetByIdAppointmentAsync(int id);
        Task CreateAsync(CreateAppointmentDto dto);
        Task UpdatetAsync(UpdateAppointmentDto dto);
        Task DeleteAsync(int id);
    }
}
