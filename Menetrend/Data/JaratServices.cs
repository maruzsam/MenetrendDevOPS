using Menetrend.Models;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace Menetrend.Data
{
    public class JaratServices
    {
        private readonly IMongoCollection<Jarat> _collection;

        public JaratServices(IOptions<DatabaseSettings> databaseSettings)
        {
            var mongoClient = new MongoClient(
            databaseSettings.Value.ConnectionString);

            var mongoDatabase = mongoClient.GetDatabase(
                databaseSettings.Value.DatabaseName);

            _collection = mongoDatabase.GetCollection<Jarat>(
                databaseSettings.Value.JaratCollectionName);
        }

        public async Task<List<Jarat>> GetAll() =>
            await _collection.Find(_ => true).ToListAsync();
        public async Task<Jarat?> GetAsync(string id) =>
            await _collection.Find(x => x.Id == id).FirstOrDefaultAsync();

        public async Task CreateAsync(Jarat newBook) =>
            await _collection.InsertOneAsync(newBook);

        public async Task UpdateAsync(string id, Jarat updatedBook) =>
            await _collection.ReplaceOneAsync(x => x.Id == id, updatedBook);

        public async Task RemoveAsync(string id) =>
            await _collection.DeleteOneAsync(x => x.Id == id);
    }
}
