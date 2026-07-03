using Doccure.AppointmentService.Dtos.AppointmentDtos;

namespace Doccure.AppointmentService.Services
{
    public interface IAppointmentServices
    {
        Task<List<ResultAppointmentDto>> GetAllAsync();
        Task<GetAppointmentByIdDto> GetByIdAsync(int id);
        Task CreateAsync(CreateAppointmentDto dto);
        Task UpdateAsync(UpdateAppointmentDto dto);
        Task DeleteAsync(int id);
        
    }
}
