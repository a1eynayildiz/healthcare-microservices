using Microsoft.EntityFrameworkCore;

namespace Doccure.AppointmentService.Context
{
    public class AppointmentContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=localhost\\SQLEXPRESS; initial catalog=DoccureAppointmentDb; Trusted_Connection=True;TrustServerCertificate=True; ");
         
        }
        public AppointmentContext(DbContextOptions<AppointmentContext> options) : base(options)
        {
        }
        public DbSet<Entities.Appointment> Appointments { get; set; }
        public DbSet<Entities.AppointmentDetail> AppointmentDetails { get; set; }
        public DbSet<Entities.DoctorSchedule> DoctorSchedules { get; set; }
    
    
    }
}
