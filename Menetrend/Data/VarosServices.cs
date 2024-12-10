using Menetrend.Models;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace Menetrend.Data
{
    public class VarosServices
    {
        private readonly IMongoCollection<Varos> _collection;

        public VarosServices(IOptions<DatabaseSettings> databaseSettings)
        {
            var mongoClient = new MongoClient(
            databaseSettings.Value.ConnectionString);

            var mongoDatabase = mongoClient.GetDatabase(
                databaseSettings.Value.DatabaseName);

            _collection = mongoDatabase.GetCollection<Varos>(
                databaseSettings.Value.VarosCollectionName);
        }

        public async Task<List<Varos>> GetAll() =>
            await _collection.Find(_ => true).ToListAsync();
        public async Task<Varos?> GetAsync(string id) =>
            await _collection.Find(x => x.Id == id).FirstOrDefaultAsync();

        public async Task CreateAsync(Varos newBook) =>
            await _collection.InsertOneAsync(newBook);

        public async Task UpdateAsync(string id, Varos updatedBook) =>
            await _collection.ReplaceOneAsync(x => x.Id == id, updatedBook);

        public async Task RemoveAsync(string id) =>
            await _collection.DeleteOneAsync(x => x.Id == id);
    }
}
