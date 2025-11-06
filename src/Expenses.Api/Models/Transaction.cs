namespace Expenses.Api.Models;

public sealed class Transaction
{
    public Guid Id { get; set; }
    public string Type { get; set; }
    public double Amount { get; set; }
    public string Category { get; set; }
    public DateTimeOffset CreatedAt { get; set; }
    public DateTimeOffset UpdatedAt { get; set; }
}
