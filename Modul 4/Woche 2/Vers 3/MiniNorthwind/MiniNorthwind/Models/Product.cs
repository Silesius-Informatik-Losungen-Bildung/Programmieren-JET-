using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MiniNorthwind.Models;

public class Product
{
    [Key]
    public int ProductId { get; set; }

    [MaxLength(40)]
    public string ProductName { get; set; } = null!;

    public int? SupplierId { get; set; }

    public int? CategoryId { get; set; }

    [MaxLength(20)]
    public string? QuantityPerUnit { get; set; }

    [Column(TypeName = "decimal(18,2)")]
    public decimal? UnitPrice { get; set; }

    public short? UnitsInStock { get; set; } = 0;

    public short? UnitsOnOrder { get; set; } = 0;

    public short? ReorderLevel { get; set; } = 0;

    public bool Discontinued { get; set; } 

    public virtual Category? Category { get; set; }

    public virtual Supplier? Supplier { get; set; }
}
