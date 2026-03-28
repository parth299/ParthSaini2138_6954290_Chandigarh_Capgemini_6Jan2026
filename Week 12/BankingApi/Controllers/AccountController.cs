using AutoMapper;
using BankingApi.Data;
using BankingApi.DTOs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BankingApi.Controllers
{
    [ApiController]
    [Route("api/account")]
    [Authorize]
    public class AccountController : ControllerBase
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;

        public AccountController(
            AppDbContext context,
            IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        // USER VIEW (Masked)
        [HttpGet("masked")]
        public IActionResult GetMaskedAccount()
        {
            var account = _context.Accounts.First();

            var dto = _mapper.Map<UserAccountDTO>(account);

            return Ok(dto);
        }

        // ADMIN VIEW (Full)
        [HttpGet("details")]
        [Authorize(Roles = "Admin")]
        public IActionResult GetFullAccount()
        {
            var account = _context.Accounts.First();

            var dto = _mapper.Map<AdminAccountDTO>(account);

            return Ok(dto);
        }
    }
}