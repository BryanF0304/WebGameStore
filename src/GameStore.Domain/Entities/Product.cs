namespace GameStore.Domain.Entities;

public class Product
{
    public Guid Id { get; private set; }
    public string Title { get; private set; } = string.Empty;
    public string Description { get; private set; } = string.Empty;
    public decimal Price { get; private set; }
    public int Stock { get; private set; }
    public string ImageUrl { get; private set; } = string.Empty;
    public Guid CategoryId { get; private set; }
    public string Platform { get; private set; } = string.Empty;  // PS5/Xbox/PC/Switch
    public string Genre { get; private set; } = string.Empty;     // RPG/Acción/Deportes/etc
    public List<string> Tags { get; private set; } = new();
    public bool NeedsReindex { get; private set; } = true;
    public DateTime? LastIndexedAt { get; private set; }
    public DateTime CreatedAt { get; private set; }
    public DateTime UpdatedAt { get; private set; }

    // Navegación
    public Category Category { get; private set; } = null!;

    private Product() { }

    public static Product Create(
        string title,
        string description,
        decimal price,
        int stock,
        string imageUrl,
        Guid categoryId,
        string platform,
        string genre,
        List<string>? tags = null)
    {
        return new Product
        {
            Id = Guid.NewGuid(),
            Title = title,
            Description = description,
            Price = price,
            Stock = stock,
            ImageUrl = imageUrl,
            CategoryId = categoryId,
            Platform = platform,
            Genre = genre,
            Tags = tags ?? new List<string>(),
            NeedsReindex = true,
            CreatedAt = DateTime.UtcNow,
            UpdatedAt = DateTime.UtcNow
        };
    }

    public void UpdateStock(int newStock)
    {
        if (newStock < 0) throw new ArgumentException("El stock no puede ser negativo.");
        Stock = newStock;
        UpdatedAt = DateTime.UtcNow;
    }

    public void UpdatePrice(decimal newPrice)
    {
        if (newPrice <= 0) throw new ArgumentException("El precio debe ser mayor a cero.");
        Price = newPrice;
        UpdatedAt = DateTime.UtcNow;
    }

    public bool IsInStock() => Stock > 0;

    public void SetAsIndexed()
    {
        NeedsReindex = false;
        LastIndexedAt = DateTime.UtcNow;
    }
}