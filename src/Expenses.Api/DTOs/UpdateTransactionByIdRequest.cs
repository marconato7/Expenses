namespace Expenses.Api.DTOs;

public sealed class UpdateTransactionByIdRequest
{
    public string Type { get; set; }
    public double Amount { get; set; }
    public string Category { get; set; }
}
