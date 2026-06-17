using GameStore.Domain.Entities;

namespace GameStore.Domain.Interfaces;

public interface IProductRepository
{
    Task<Product?> GetByIdAsync(Guid id);
    Task<IEnumerable<Product>> GetAllAsync();
    Task<IEnumerable<Product>> SearchAsync(string query);
    Task<IEnumerable<Product>> BuscarPorFiltrosAsync(
        string? platform,
        string? genre,
        decimal? maxPrice,
        List<string>? tags,
        int limit = 20);
    Task<IEnumerable<Product>> GetPendingReindexAsync(int limit);
    Task AddAsync(Product product);
    Task UpdateAsync(Product product);
    Task DeleteAsync(Guid id);
}