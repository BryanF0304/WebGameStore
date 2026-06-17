namespace GameStore.Domain.Entities;

public class Category
{
    public Guid Id { get; private set; }
    public string Name { get; private set; } = string.Empty;
    public string Slug { get; private set; } = string.Empty;
    public string Description { get; private set; } = string.Empty;
    public string IconClass { get; private set; } = string.Empty;

    public ICollection<Product> Products { get; private set; } = new List<Product>();

    private Category() { }

    public static Category Create(string name, string slug, string description, string iconClass)
    {
        return new Category
        {
            Id = Guid.NewGuid(),
            Name = name,
            Slug = slug,
            Description = description,
            IconClass = iconClass
        };
    }
}