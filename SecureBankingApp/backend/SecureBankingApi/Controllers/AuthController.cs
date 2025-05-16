using Microsoft.AspNetCore.Mvc;
using SecureBankingApi.Models;

namespace SecureBankingApi.Controllers;

[ApiController]
[Route("api/[controller]/[action]")]
public class AuthController : ControllerBase
{
    private static readonly string storedEmail = "test@example.com";
    private static readonly string storedPasswordHash = "8d969eef6ecad3c29a3a629280e686cf0c3f5d5a86aff3ca12020c923adc6c92";

    [HttpPost]
    public IActionResult Login(LoginRequest request)
    {
        Console.WriteLine($"Email: {request.Email}");
        Console.WriteLine($"PasswordHash: {request.PasswordHash}");

        if (request.Email == storedEmail && request.PasswordHash == storedPasswordHash)
        {
            return Ok(new { message = "Login successful!" });
        }

        return Unauthorized(new { message = "Invalid login credentials" });
    }
}
