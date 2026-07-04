using Doccure.AppointmentService.Dtos.AppointmentDtos;
using Doccure.AppointmentService.Services.AppointmentServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Doccure.AppointmentService.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class AppointmentsController : ControllerBase
    {
        private readonly IAppointmentServices _service;

        public AppointmentsController(IAppointmentServices service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAppointment()
        {
            var values = await _service.GetAllAsync();
            return Ok(values);
        }

        
        [HttpGet("GetAppointment")]
        public async Task<IActionResult> GetAppointment(int id)
        {
            var value = await _service.GetByIdAsync(id);

            if (value == null)
            {
                return NotFound("Appointment not found.");
            }
            return Ok(value);
        }

        
        [HttpPost]
        public async Task<IActionResult> CreateAppointment(CreateAppointmentDto dto)
        {
            await _service.CreateAsync(dto);
            return Ok("Appointment added successfully.");
        }


        [HttpPut]
        public async Task<IActionResult> UpdateAppointment(UpdateAppointmentDto dto)
        {
            await _service.UpdateAsync(dto);
            return Ok("Updated successfully!");
        }

        
        [HttpDelete]
        public async Task<IActionResult> DeleteAppointment(int id)
        {
            await _service.DeleteAsync(id);
            return Ok("Silme başarılı!");
        }
    }
}
