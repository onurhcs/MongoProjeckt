using MyMongoProjecktNight.Dtos.DepartmentDtos;

namespace MyMongoProjecktNight.Services.DepartmentServices
{
    public interface IDepartmentService
    {
        Task<List<ResultDepartmentDto>> GetAllDepartmentAsync();
        Task CreateDepartmentAsync(CreateDepartmentDto createDepartmentDto);
        Task UpdateDepartmentAsync(UpdateDepartmentDto updateDepartmentDto);
        Task DeleteDepartmentAsync(string DepartmentId);
        Task<GetByIdDepartmentDto> GetByIdDepartmentAsync(string DepartmentId);
    }
}
