using Expenses.Api.Data;
using Expenses.Api.DTOs;
using Expenses.Api.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Expenses.Api.Controllers;

[ApiController]
public class DeleteTransactionByIdController : ControllerBase
{
    private readonly ApplicationDbContext _applicationDbContext;

    public DeleteTransactionByIdController(
        ApplicationDbContext applicationDbContext
    )
    {
        _applicationDbContext = applicationDbContext;
    }

    [HttpDelete]
    [Route("api/transactions/{id:guid}")]
    public async Task<IActionResult> DeleteTransactionById(
        Guid id,
        CancellationToken cancellationToken
    )
    {
        var transaction = await _applicationDbContext
            .Set<Transaction>()
            .SingleOrDefaultAsync(t => t.Id == id, cancellationToken: cancellationToken);

        if (transaction is null)
        {
            return NotFound();
        }

        _applicationDbContext.Remove(transaction);

        await _applicationDbContext.SaveChangesAsync(cancellationToken);

        return Ok(transaction);
    }
}
