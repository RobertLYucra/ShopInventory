using MongoDB.Bson;
using MongoDB.Driver;
using ShopInventory.Model;
using ShopInventory.Repository.Interfaces;

namespace ShopInventory.Repository
{
    public class ProductCollection : IProductCollection
    {
        internal MongodbRepository _mongoDBRepository = new MongodbRepository();
        private IMongoCollection<Product> Collection;

        public ProductCollection()
        {
            Collection = _mongoDBRepository.db.GetCollection<Product>("Products");
        }

        public async Task DeleteProduct(string id)
        {
            var filter = Builders<Product>.Filter.Eq(x => x.Id, new ObjectId(id));
            await Collection.DeleteOneAsync(filter);
        }

        public async Task<List<Product>> GetAllProdcut()
        {
            return await Collection
                .FindAsync(new BsonDocument())
                .Result
                .ToListAsync();
        }

        public async Task<Product> GetProductById(string id)
        {
            return await Collection.FindAsync(new BsonDocument { { "_id", new ObjectId(id) } })
                .Result
                .FirstAsync();
        }

        public async Task InsertProduct(Product product)
        {
            await Collection.InsertOneAsync(product);
        }

        public async Task UpdateProduct(Product product)
        {
            var filter = Builders<Product>
                .Filter
                .Eq(x => x.Id, product.Id);
            await Collection.ReplaceOneAsync(filter, product);
        }
    }
}
