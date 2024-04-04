using VoLeAnhTien_2180604444_Tuan6.Models;

namespace VoLeAnhTien_2180604444_Tuan6.Respository
{
    public interface ICategoryRepository
    {
        Task<IEnumerable<Category>> GetAllAsync();
        Task<Category> GetByIdAsync(int id);
        Task AddAsync(Category category);
        Task UpdateAsync(Category category);
        Task DeleteAsync(int id);
    }
}
