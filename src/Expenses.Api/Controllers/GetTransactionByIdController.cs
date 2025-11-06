using Expenses.Api.Data;
using Expenses.Api.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Expenses.Api.Controllers;

[ApiController]
public class GetTransactionByIdController : ControllerBase
{
    private readonly ApplicationDbContext _applicationDbContext;

    public GetTransactionByIdController(
        ApplicationDbContext applicationDbContext
    )
    {
        _applicationDbContext = applicationDbContext;
    }

    [HttpPost]
    [Route("api/transactions/{id:guid}")]
    public async Task<IActionResult> GetTransactionById(
        Guid id,
        CancellationToken cancellationToken
    )
    {
        var transaction = await _applicationDbContext
            .Set<Transaction>()
            .AsNoTracking()
            .SingleOrDefaultAsync(t => t.Id == id, cancellationToken: cancellationToken);

        if (transaction is null)
        {
            return NotFound();
        }

        return Ok(transaction);
    }
}
