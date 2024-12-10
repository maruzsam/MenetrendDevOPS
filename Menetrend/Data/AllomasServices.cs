using Menetrend.Models;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace Menetrend.Data
{
    public class AllomasServices
    {
        private readonly IMongoCollection<Allomas> _collection;

        public AllomasServices(IOptions<DatabaseSettings> databaseSettings)
        {
            var mongoClient = new MongoClient(
            databaseSettings.Value.ConnectionString);

            var mongoDatabase = mongoClient.GetDatabase(
                databaseSettings.Value.DatabaseName);

            _collection = mongoDatabase.GetCollection<Allomas>(
                databaseSettings.Value.AllomasCollectionName);
        }

        public async Task<List<Allomas>> GetAll() =>
            await _collection.Find(_ => true).ToListAsync();
        public async Task<Allomas?> GetAsync(string id) =>
            await _collection.Find(x => x.Id == id).FirstOrDefaultAsync();

        public async Task CreateAsync(Allomas newBook) =>
            await _collection.InsertOneAsync(newBook);

        public async Task UpdateAsync(string id, Allomas updatedBook) =>
            await _collection.ReplaceOneAsync(x => x.Id == id, updatedBook);

        public async Task RemoveAsync(string id) =>
            await _collection.DeleteOneAsync(x => x.Id == id);
    }
}
