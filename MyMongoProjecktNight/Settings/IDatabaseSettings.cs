namespace MyMongoProjecktNight.Settings
{
    public interface IDatabaseSettings
    {
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }
        public string CustomerCollectionName { get; set; }
        public string DepartmentCollectionName { get; set; }
    }
}
