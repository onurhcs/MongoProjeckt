using Microsoft.AspNetCore.Mvc;
using MyMongoProjecktNight.Dtos.DepartmentDtos;
using MyMongoProjecktNight.Dtos.DepartmentDtos;
using MyMongoProjecktNight.Services;
using MyMongoProjecktNight.Services.DepartmentServices;

namespace MyMongoProjecktNight.Controllers
{
    public class DepartmentController : Controller
    {
        private readonly IDepartmentService _departmentService;

        public DepartmentController(IDepartmentService departmentService)
        {
            _departmentService = departmentService;
        }

        [HttpGet]
        public IActionResult CreateDepartment()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> CreateDepartment(CreateDepartmentDto createDepartmentDto)
        {
            await _departmentService.CreateDepartmentAsync(createDepartmentDto);
            return RedirectToAction("DepartmentList");
        }
        [HttpGet]
        public async Task<IActionResult> DepartmentList()
        {
            var Departments = await _departmentService.GetAllDepartmentAsync();
            return View(Departments);
        }

        [HttpPost]
        public async Task<IActionResult> DepartmentDelete(string id)
        {
            await _departmentService.DeleteDepartmentAsync(id);
            return RedirectToAction("DepartmentList");
        }

        [HttpGet]
        public async Task<IActionResult> UpdateDepartment(string id)
        {
            var Department = await _departmentService.GetByIdDepartmentAsync(id);
            if (Department == null)
            {
                return NotFound();
            }
            return View(Department);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateDepartment(UpdateDepartmentDto updateDepartmentDto)
        {
            await _departmentService.UpdateDepartmentAsync(updateDepartmentDto);
            return RedirectToAction("DepartmentList");
        }

        [HttpGet]
        public async Task<IActionResult> DepartmentDetails(string id)
        {
            var Department = await _departmentService.GetByIdDepartmentAsync(id);
            if (Department == null)
            {
                return NotFound();
            }
            return View(Department);
        }
    }
}
