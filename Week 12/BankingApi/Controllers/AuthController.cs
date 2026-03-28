using BankingApi.Data;
using BankingApi.DTOs;
using BankingApi.Models;
using BankingApi.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BankingApi.Controllers
{
    [ApiController]
    [Route("api/auth")]
    public class AuthController : ControllerBase
    {
        private readonly AppDbContext _context;
        private readonly JwtService _jwtService;
        private readonly PasswordService _passwordService;

        public AuthController(
            AppDbContext context,
            JwtService jwtService,
            PasswordService passwordService)
        {
            _context = context;
            _jwtService = jwtService;
            _passwordService = passwordService;
        }

        // REGISTER USER
        [HttpPost("register")]
        public async Task<IActionResult> Register(
            RegisterDTO dto)
        {
            if (await _context.Users
                .AnyAsync(x => x.Username == dto.Username))
            {
                return BadRequest("User already exists");
            }

            var user = new User
            {
                Username = dto.Username,
                PasswordHash =
                    _passwordService
                        .HashPassword(dto.Password),
                Role = dto.Role ?? "User"
            };

            _context.Users.Add(user);
            await _context.SaveChangesAsync();

            // Create Account automatically
            var account = new Account
            {
                AccountHolderName = dto.Username,
                AccountNumber =
                    GenerateAccountNumber(),
                Balance = 1000,
                UserId = user.Id
            };

            _context.Accounts.Add(account);
            await _context.SaveChangesAsync();

            return Ok("User Registered");
        }


        // LOGIN USER
        [HttpPost("login")]
        public async Task<IActionResult> Login(
            LoginDTO dto)
        {
            var user = await _context.Users
                .FirstOrDefaultAsync(
                    x => x.Username == dto.Username);

            if (user == null)
                return Unauthorized("Invalid User");

            var validPassword =
                _passwordService.VerifyPassword(
                    dto.Password,
                    user.PasswordHash);

            if (!validPassword)
                return Unauthorized("Invalid Password");

            var token =
                _jwtService.GenerateToken(
                    user.Username,
                    user.Role);

            return Ok(new { token });
        }


        private string GenerateAccountNumber()
        {
            var rand = new Random();

            return rand
                .Next(100000000, 999999999)
                .ToString();
        }
    }
}