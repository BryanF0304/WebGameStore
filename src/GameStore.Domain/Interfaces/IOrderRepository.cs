using GameStore.Domain.Entities;

namespace GameStore.Domain.Interfaces;

public interface IOrderRepository
{
    Task<Order?> GetByIdAsync(Guid id);
    Task<IEnumerable<Order>> GetByUserIdAsync(string userId);
    Task<Guid> CrearOrdenAsync(string userId, decimal total, string stripePaymentId);
}