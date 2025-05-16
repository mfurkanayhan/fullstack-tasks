using backend.Hubs;
using backend.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;

namespace backend.Controllers;

[ApiController]
[Route("api/[controller]/[action]")]
public sealed class TransactionController : ControllerBase
{
    private readonly IHubContext<TransactionHub> _hub;

    public TransactionController(IHubContext<TransactionHub> hub)
    {
        _hub = hub;
    }

    [HttpPost]
    public async Task<IActionResult> Save (Transaction transaction)
    {
        Console.WriteLine("New transaction received:");
        Console.WriteLine($"Date: {transaction.Date}");
        Console.WriteLine($"Description: {transaction.Description}");
        Console.WriteLine($"Amount: {transaction.Amount}");

        await _hub.Clients.All.SendAsync("TransactionReceived", transaction);
        return Ok(new { message = "Transaction broadcasted successfully." });
    }
}
