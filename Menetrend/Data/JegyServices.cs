using Menetrend.Models;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace Menetrend.Data
{
    public class JegyServices
    {
        private readonly IMongoCollection<Jegy> _collection;

        public JegyServices(IOptions<DatabaseSettings> databaseSettings)
        {
            var mongoClient = new MongoClient(
            databaseSettings.Value.ConnectionString);

            var mongoDatabase = mongoClient.GetDatabase(
                databaseSettings.Value.DatabaseName);

            _collection = mongoDatabase.GetCollection<Jegy>(
                databaseSettings.Value.JegyCollectionName);
        }

        public async Task<List<Jegy>> GetAll() =>
            await _collection.Find(_ => true).ToListAsync();
        public async Task<Jegy?> GetAsync(string id) =>
            await _collection.Find(x => x.Id == id).FirstOrDefaultAsync();

        public async Task CreateAsync(Jegy newBook) =>
            await _collection.InsertOneAsync(newBook);

        public async Task UpdateAsync(string id, Jegy updatedBook) =>
            await _collection.ReplaceOneAsync(x => x.Id == id, updatedBook);

        public async Task RemoveAsync(string id) =>
            await _collection.DeleteOneAsync(x => x.Id == id);
    }
}
