using Microsoft.AspNetCore.Identity;

namespace GameStore.Domain.Entities;

public class ApplicationUser : IdentityUser
{
    public string FullName { get; set; } = string.Empty;
    public string AvatarUrl { get; set; } = string.Empty;
    public List<string> FavoriteGenres { get; set; } = new();
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
}