using Doccure.DoctorService.Dtos.DoctorDtos;
using Doccure.DoctorService.Services.DoctorServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Doccure.DoctorService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DoctorsController : ControllerBase
    {
        private readonly IDoctorService _doctorService;

        public DoctorsController(IDoctorService doctorService)
        {
            _doctorService = doctorService;
        }

        //  Tüm doktorları listele
        [HttpGet]
        public async Task<IActionResult> DoctorList()
        {
            var values = await _doctorService.GetAllDoctorAsync();
            return Ok(values);
        }

        //ID'ye göre doktor getir
        [HttpGet("{id}")]
        public async Task<IActionResult> GetDoctor(string id)
        {
            var value = await _doctorService.GetByIdDoctorAsync(id);
            return Ok(value);
        }

        
        [HttpPost]
        public async Task<IActionResult> CreateDoctor(CreateDoctorDto dto)
        {
            await _doctorService.CreateDoctorAsync(dto);
            return Ok("Doctor added successfully.");
        }

        // Doktor güncelle
        [HttpPut]
        public async Task<IActionResult> UpdateDoctor(UpdateDoctorDto dto)
        {
            await _doctorService.UpdateDoctorAsync(dto);
            return Ok("Doctor updated successfully.");
        }

        // ID'ye göre doktor sil
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDoctor(string id)
        {
            await _doctorService.DeleteDoctorAsync(id);
            return Ok("Doctor deleted successfully.");
        }
    }
}
