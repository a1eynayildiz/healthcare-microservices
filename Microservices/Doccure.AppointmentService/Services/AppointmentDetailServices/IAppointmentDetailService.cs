using Doccure.AppointmentService.Dtos.AppointmentDetail;

namespace Doccure.AppointmentService.Services.AppointmentDetailServices
{
    public interface IAppointmentDetailService
    {
        Task<ResultAppointmentDetailDto> GetByAppointmentIdAsync(int appointmentId);
        
        Task CreateAsync(CreateAppointmentDetailDto dto);
        Task UpdateAsync(UpdateAppointmentDetailDto dto);
        
    }
}
