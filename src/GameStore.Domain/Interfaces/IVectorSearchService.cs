using GameStore.Domain.Entities;

namespace GameStore.Domain.Interfaces;

public record VectorSearchResult(Product Product, double Score);

public interface IVectorSearchService
{
    Task IndexProductAsync(Product product);
    Task<IEnumerable<VectorSearchResult>> SearchSimilarAsync(string query, int limit = 5);
    Task DeleteProductIndexAsync(Guid productId);
}