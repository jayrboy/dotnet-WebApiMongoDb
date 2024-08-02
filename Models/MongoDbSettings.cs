namespace WebApiMongoDb.Models
{
    public class MongoDbSettings
    {
        public string ConnectionURL { get; set; } = null!;
        public string DatabaseName { get; set; } = null!;
        public string ConnectionName { get; set; } = null!;
    }
}