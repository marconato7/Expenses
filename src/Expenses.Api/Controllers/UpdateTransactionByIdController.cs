using Expenses.Api.Data;
using Expenses.Api.DTOs;
using Expenses.Api.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Expenses.Api.Controllers;

[ApiController]
public class UpdateTransactionByIdController : ControllerBase
{
    private readonly ApplicationDbContext _applicationDbContext;

    public UpdateTransactionByIdController(
        ApplicationDbContext applicationDbContext
    )
    {
        _applicationDbContext = applicationDbContext;
    }

    [HttpPut]
    [Route("api/transactions/{id:guid}")]
    public async Task<IActionResult> UpdateTransaction(
        [FromRoute] Guid id,
        [FromBody] UpdateTransactionByIdRequest request,
        CancellationToken cancellationToken
    )
    {
        var transaction = await _applicationDbContext
            .Set<Transaction>()
            .SingleOrDefaultAsync(
                t => t.Id == id,
                cancellationToken: cancellationToken
            );

        if (transaction is null)
        {
            return NotFound();
        }

        transaction.Type = request.Type;
        transaction.Amount = request.Amount;
        transaction.Category = request.Category;
        transaction.UpdatedAt = DateTimeOffset.UtcNow;

        await _applicationDbContext
            .SaveChangesAsync(cancellationToken);

        return Ok(transaction);
    }
}
