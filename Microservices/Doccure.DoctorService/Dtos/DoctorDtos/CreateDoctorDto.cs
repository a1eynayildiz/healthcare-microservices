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
        

        //SubCollectionlar :İç içe veri tutabilir.
        public List<Education> Educations { get; set; } = new List<Education>();
        public List<Experience> Experiences { get; set; } = new List<Experience>();
        public List<Award> Awards { get; set; } = new List<Award>();
        public List<string> Services { get; set; }
        public List<string> Specializations { get; set; } = new List<string>();
    }
}
