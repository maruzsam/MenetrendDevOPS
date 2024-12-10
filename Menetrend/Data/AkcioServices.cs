using Menetrend.Models;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace Menetrend.Data
{
    public class AkcioServices
    {
        private readonly IMongoCollection<Akcio> _collection;

        public AkcioServices(IOptions<DatabaseSettings> databaseSettings)
        {
            var mongoClient = new MongoClient(
            databaseSettings.Value.ConnectionString);

            var mongoDatabase = mongoClient.GetDatabase(
                databaseSettings.Value.DatabaseName);

            _collection = mongoDatabase.GetCollection<Akcio>(
                databaseSettings.Value.AkcioCollectionName);
        }

        public async Task<List<Akcio>> GetAll() =>
            await _collection.Find(_ => true).ToListAsync();
        public async Task<Akcio?> GetAsync(string id) =>
            await _collection.Find(x => x.Id == id).FirstOrDefaultAsync();

        public async Task CreateAsync(Akcio newBook) =>
            await _collection.InsertOneAsync(newBook);

        public async Task UpdateAsync(string id, Akcio updatedBook) =>
            await _collection.ReplaceOneAsync(x => x.Id == id, updatedBook);

        public async Task RemoveAsync(string id) =>
            await _collection.DeleteOneAsync(x => x.Id == id);
    }
}
