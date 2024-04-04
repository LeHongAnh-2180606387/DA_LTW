using VoLeAnhTien_2180604444_Tuan6.Models;

namespace VoLeAnhTien_2180604444_Tuan6.Respository
{
    public interface IProductRepository
    {
        Task<IEnumerable<Product>> GetAllAsync();
        Task<Product> GetByIdAsync(int id);
        Task AddAsync(Product product);
        Task UpdateAsync(Product product);
        Task DeleteAsync(int id);
    }
}
