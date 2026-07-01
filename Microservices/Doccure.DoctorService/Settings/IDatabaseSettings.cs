namespace Doccure.DoctorService.Settings
{
    public interface IDatabaseSettings
    {
        public string ConnectionString { get; set; } //bağlantı adresi 
        public string DatabaseName { get; set; }
        public string DoctorCollectionName { get; set; }
    }
}
