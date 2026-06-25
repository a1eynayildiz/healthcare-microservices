namespace Doccure.BranchService.Settings
{
    /// <summary>
    /// Veritabanı ayarları için sözleşme (contract).
    /// Bu interface, veritabanı bağlantı bilgilerini standartlaştırır.
    /// Implement eden sınıflar bu üç property'i sağlamak zorundadır.
    /// 
    /// NOT: Interface kullanmamızın sebebi Dependency Inversion (SOLID prensibi).
    /// Repository sınıfımız concrete class yerine bu interface'e bağımlı olacak,
    /// böylece ileride farklı ayar kaynakları (test, prod, vs.) eklemek kolay olur.
    /// </summary>
    public interface IDatabaseSettings
    {
        public string ConnectionString { get; set; } //bağlantı adresi 
        public string DatabaseName { get; set; } 
        public string BranchCollectionName { get; set; } 
    }
}
