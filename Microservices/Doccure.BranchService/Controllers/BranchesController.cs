using Doccure.BranchService.Dtos.BranchDtos;
using Doccure.BranchService.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Doccure.BranchService.Controllers
{
    [Route("api/[controller]")]// İsteklerin yapılacağı URL yolunu belirler
    [ApiController]
    public class BranchesController : ControllerBase
    {
        private readonly IBranchService _branchService;

        public BranchesController(IBranchService branchService)
        {
            _branchService = branchService;
        }

        //Endpointler
        [HttpGet]
        public async Task<IActionResult> BranchList()
        {
            var values = await _branchService.GetAllBranchAsync();//veri aldık (var values...)
            return Ok(values);
        }
        [HttpPost]
        public async Task<IActionResult> CreateBranch(CreateBranchDto createBranchDto)
        {
            await _branchService.CreateBranchAsync(createBranchDto);
            return Ok("Branch added successfully.");
        }
        [HttpDelete]
        public async Task<IActionResult> DeleteBranch(string id)
        {
            await _branchService.DeleteBranchAsync(id);//veri almadık,kaydettik
            return Ok("Silme başarılı!");
        }

        [HttpPut]
        public async Task<IActionResult> UpdateBranch(UpdateBranchDto updateBranchDto)
        {
            await _branchService.UpdateBranchAsync(updateBranchDto);
            return Ok("Güncelleme başarılı!");
        }

        ///Controller içinde daha önce httpget kullandığından ikincisnin isimlendirilmesi gerekiyor.
        [HttpGet("GetBranch")]//Branch'i IP ile birlikte getirir.
        public async Task<IActionResult>GetBranch(string id)
        {
            var value = await _branchService.GetByIdBranchAsync(id);
            return Ok(value);
        }


    }
}
