using Menetrend.Models;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace Menetrend.Data
{
    public class ProductionServices
    {
        private readonly IMongoCollection<Product> _collection;

        public ProductionServices(IOptions<DatabaseSettings> databaseSettings)
        {
            var mongoClient = new MongoClient(
            databaseSettings.Value.ConnectionString);

            var mongoDatabase = mongoClient.GetDatabase(
                databaseSettings.Value.DatabaseName);

            _collection = mongoDatabase.GetCollection<Product>(
                databaseSettings.Value.ProductCollectionName);
        }

        public async Task<List<Product>> GetAll() =>
            await _collection.Find(_ => true).ToListAsync();
        public async Task<Product?> GetAsync(string id) =>
            await _collection.Find(x => x.Id == id).FirstOrDefaultAsync();

        public async Task CreateAsync(Product newBook) =>
            await _collection.InsertOneAsync(newBook);

        public async Task UpdateAsync(string id, Product updatedBook) =>
            await _collection.ReplaceOneAsync(x => x.Id == id, updatedBook);

        public async Task RemoveAsync(string id) =>
            await _collection.DeleteOneAsync(x => x.Id == id);
    }
}
