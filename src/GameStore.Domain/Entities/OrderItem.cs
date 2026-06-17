namespace GameStore.Domain.Entities;

public class OrderItem
{
    public Guid Id { get; private set; }
    public Guid OrderId { get; private set; }
    public Guid ProductId { get; private set; }
    public int Quantity { get; private set; }
    public decimal UnitPrice { get; private set; }

    // Navegación
    public Order Order { get; private set; } = null!;
    public Product Product { get; private set; } = null!;

    private OrderItem() { }

    public static OrderItem Create(Guid orderId, Guid productId, int quantity, decimal unitPrice)
    {
        if (quantity <= 0) throw new ArgumentException("La cantidad debe ser mayor a cero.");
        if (unitPrice <= 0) throw new ArgumentException("El precio unitario debe ser mayor a cero.");

        return new OrderItem
        {
            Id = Guid.NewGuid(),
            OrderId = orderId,
            ProductId = productId,
            Quantity = quantity,
            UnitPrice = unitPrice
        };
    }
}