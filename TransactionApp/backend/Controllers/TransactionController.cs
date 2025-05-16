using backend.Models;
using Microsoft.AspNetCore.Mvc;

namespace backend.Controllers;

[ApiController]
[Route("api/[controller]/[action]")]
public sealed class TransactionController : ControllerBase
{
    [HttpPost]
    public IActionResult Save(Transaction transaction)
    {
        Console.WriteLine("New transaction received:");
        Console.WriteLine($"Date: {transaction.Date}");
        Console.WriteLine($"Description: {transaction.Description}");
        Console.WriteLine($"Amount: {transaction.Amount}");

        return Ok(new { message = "Transaction saved successfully." });
    }
}
