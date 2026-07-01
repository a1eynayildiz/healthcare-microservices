using Doccure.DoctorService.Entities;

namespace Doccure.DoctorService.Dtos.DoctorDtos
{
    public class CreateDoctorDto
    {
        //DoctorID MongoDB tarafından otomatik olarak oluşturulacak ve atanacaktır. 
        public string? Name { get; set; }
        public string? Surname { get; set; }
        public string? BranchId { get; set; }

        public string? Email { get; set; }
        public string? Phone { get; set; }
        public string? ImageUrl { get; set; }
        public string? About { get; set; }
        public int ExperienceYear { get; set; }
        public decimal PricePerHour { get; set; }

        public List<EducationDto> Educations { get; set; } = new List<EducationDto>();
        public List<ExperienceDto> Experiences { get; set; } = new List<ExperienceDto>();
        public List<AwardDto> Awards { get; set; } = new List<AwardDto>();
        public List<LocationDto> Locations { get; set; } = new List<LocationDto>();
        public List<string> Services { get; set; } = new List<string>();
        public List<string> Specializations { get; set; } = new List<string>();
    }
}
