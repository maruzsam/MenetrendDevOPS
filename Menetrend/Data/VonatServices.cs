using Menetrend.Models;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace Menetrend.Data
{
    public class VonatServices
    {
        private readonly IMongoCollection<Vonat> _collection;

        public VonatServices(IOptions<DatabaseSettings> databaseSettings)
        {
            var mongoClient = new MongoClient(
            databaseSettings.Value.ConnectionString);

            var mongoDatabase = mongoClient.GetDatabase(
                databaseSettings.Value.DatabaseName);

            _collection = mongoDatabase.GetCollection<Vonat>(
                databaseSettings.Value.VonatCollectionName);
        }

        public async Task<List<Vonat>> GetAll() =>
            await _collection.Find(_ => true).ToListAsync();
        public async Task<Vonat?> GetAsync(string id) =>
            await _collection.Find(x => x.Id == id).FirstOrDefaultAsync();

        public async Task CreateAsync(Vonat newBook) =>
            await _collection.InsertOneAsync(newBook);

        public async Task UpdateAsync(string id, Vonat updatedBook) =>
            await _collection.ReplaceOneAsync(x => x.Id == id, updatedBook);

        public async Task RemoveAsync(string id) =>
            await _collection.DeleteOneAsync(x => x.Id == id);
    }
}
