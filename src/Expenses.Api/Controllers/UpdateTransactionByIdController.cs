// using Expenses.Api.Data;
// using Expenses.Api.DTOs;
// using Expenses.Api.Models;
// using Microsoft.AspNetCore.Mvc;

// namespace Expenses.Api.Controllers;

// [ApiController]
// public class UpdateTransactionController : ControllerBase
// {
//     private readonly ApplicationDbContext _applicationDbContext;

//     public UpdateTransactionController(
//         ApplicationDbContext applicationDbContext
//     )
//     {
//         _applicationDbContext = applicationDbContext;
//     }

//     [HttpPost]
//     [Route("api/transactions")]
//     public async Task<IActionResult> UpdateTransaction(
//         [FromBody] UpdateTransactionRequest request,
//         CancellationToken cancellationToken
//     )
//     {
//         var transaction = new Transaction
//         {
//             Type = request.Type,
//             Amount = request.Amount,
//             Category = request.Category,
//             CreatedAt = DateTimeOffset.UtcNow,
//             UpdatedAt = DateTimeOffset.UtcNow
//         };

//         _applicationDbContext
//             .Set<Transaction>()
//             .Add(transaction);

//         await _applicationDbContext.SaveChangesAsync(cancellationToken);

//         return Ok(transaction);
//     }
// }
