using Doccure.BranchService.Dtos.BranchDtos;

namespace Doccure.BranchService.Services
{
    public interface IBranchService
    {
        // Tüm branşları listele
        Task<List<ResultBranchDto>> GetAllBranchAsync();

        // ID'ye göre tek branş getir
        Task<GetBranchByIdDto> GetByIdBranchAsync(string id);

        // Yeni branş ekle
        Task CreateBranchAsync(CreateBranchDto createBranchDto);

        // Branş güncelle
        Task UpdateBranchAsync(UpdateBranchDto updateBranchDto);

        // Branş sil
        Task DeleteBranchAsync(string id);
    }
}
