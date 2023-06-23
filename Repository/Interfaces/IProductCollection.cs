using ShopInventory.Model;

namespace ShopInventory.Repository.Interfaces
{
    public interface IProductCollection
    {
        Task InsertProduct(Product product);
        Task UpdateProduct(Product product);
        Task DeleteProduct(String id);
        Task<List<Product>> GetAllProdcut();
        Task<Product> GetProductById(String id);
    }
}
