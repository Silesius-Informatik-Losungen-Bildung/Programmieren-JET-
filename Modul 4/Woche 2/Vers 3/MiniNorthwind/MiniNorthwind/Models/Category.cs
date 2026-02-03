using System.ComponentModel.DataAnnotations;

namespace MiniNorthwind.Models;

public class Category
{
    [Key]
    public int CategoryId { get; set; }

    [MaxLength(15)]
    public string CategoryName { get; set; } = null!;

    [MaxLength(1000)]
    public string? Description { get; set; }

    public byte[]? Picture { get; set; }

    public virtual ICollection<Product> Products { get; set; } = new List<Product>();
}
