using Menetrend.Models;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace Menetrend.Data
{
    public class UtasServices
    {
        private readonly IMongoCollection<Utas> _collection;

        public UtasServices(IOptions<DatabaseSettings> databaseSettings)
        {
            var mongoClient = new MongoClient(
            databaseSettings.Value.ConnectionString);

            var mongoDatabase = mongoClient.GetDatabase(
                databaseSettings.Value.DatabaseName);

            _collection = mongoDatabase.GetCollection<Utas>(
                databaseSettings.Value.UtasCollectionName);
        }

        public async Task<List<Utas>> GetAll() =>
            await _collection.Find(_ => true).ToListAsync();
        public async Task<Utas?> GetAsync(string id) =>
            await _collection.Find(x => x.Id == id).FirstOrDefaultAsync();

        public async Task CreateAsync(Utas newBook) =>
            await _collection.InsertOneAsync(newBook);

        public async Task UpdateAsync(string id, Utas updatedBook) =>
            await _collection.ReplaceOneAsync(x => x.Id == id, updatedBook);

        public async Task RemoveAsync(string id) =>
            await _collection.DeleteOneAsync(x => x.Id == id);
    }
}
