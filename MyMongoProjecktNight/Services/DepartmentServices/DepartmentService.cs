using AutoMapper;
using MongoDB.Driver;
using MyMongoProjecktNight.Dtos.DepartmentDtos;
using MyMongoProjecktNight.Entities;
using MyMongoProjecktNight.Settings;

namespace MyMongoProjecktNight.Services.DepartmentServices
{
    public class DepartmentService : IDepartmentService
    {
        private readonly IMongoCollection<Department> _departmentCollection;
        private readonly IMapper _mapper;

        public DepartmentService(IMapper mapper, IDatabaseSettings _databaseSettings)
        {
            var client = new MongoClient(_databaseSettings.ConnectionString);
            var database = client.GetDatabase(_databaseSettings.DatabaseName);
            _departmentCollection = database.GetCollection<Department>(_databaseSettings.DepartmentCollectionName);
            _mapper = mapper;
        }

        public async Task CreateDepartmentAsync(CreateDepartmentDto createDepartmentDto)
        {
            var value = _mapper.Map<Department>(createDepartmentDto);
            await _departmentCollection.InsertOneAsync(value);
        }

        public async Task DeleteDepartmentAsync(string departmentId)
        {
            await _departmentCollection.DeleteOneAsync(d => d.DepartmentId == departmentId);
        }

        public async Task<List<ResultDepartmentDto>> GetAllDepartmentAsync()
        {
            var values = await _departmentCollection.Find(x => true).ToListAsync();
            return _mapper.Map<List<ResultDepartmentDto>>(values);
        }

        public async Task<GetByIdDepartmentDto> GetByIdDepartmentAsync(string departmentId)
        {
            var value = await _departmentCollection.Find(x => x.DepartmentId == departmentId).FirstOrDefaultAsync();
            return _mapper.Map<GetByIdDepartmentDto>(value);
        }

        public async Task UpdateDepartmentAsync(UpdateDepartmentDto updateDepartmentDto)
        {
            var value = _mapper.Map<Department>(updateDepartmentDto);
            await _departmentCollection.ReplaceOneAsync(x => x.DepartmentId == updateDepartmentDto.DepartmentId, value);
        }
    }
}