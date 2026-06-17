namespace GameStore.Domain.Entities;

public enum OrderStatus
{
    Pending,
    Confirmed,
    Shipped,
    Delivered,
    Cancelled
}

public class Order
{
    public Guid Id { get; private set; }
    public string UserId { get; private set; } = string.Empty;
    public decimal Total { get; private set; }
    public OrderStatus Status { get; private set; }
    public string StripePaymentId { get; private set; } = string.Empty;
    public DateTime CreatedAt { get; private set; }

    public ICollection<OrderItem> Items { get; private set; } = new List<OrderItem>();

    private Order() { }

    public static Order Create(string userId, decimal total, string stripePaymentId)
    {
        return new Order
        {
            Id = Guid.NewGuid(),
            UserId = userId,
            Total = total,
            Status = OrderStatus.Pending,
            StripePaymentId = stripePaymentId,
            CreatedAt = DateTime.UtcNow
        };
    }
}