using BE_QLSV.Interfaces;
using BE_QLSV.Models;
using Microsoft.AspNetCore.Mvc;

namespace BE_QLSV.Controllers
{
    [Route("api/Accounts")]
    [ApiController]
    public class AdminAccountsController : ControllerBase
    {
        private readonly IAccountService _accountService;

        public AdminAccountsController(IAccountService accountService)
        {
            _accountService = accountService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Account>>> GetAccounts()
        {
            var accounts = await _accountService.GetAllAccountsAsync();
            return Ok(accounts);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Account>> GetAccount(Guid id)
        {
            var account = await _accountService.GetAccountByIdAsync(id);
            if (account == null) return NotFound();
            return Ok(account);
        }

        [HttpPost]
        public async Task<ActionResult<Account>> CreateAccount(Account account)
        {
            var created = await _accountService.CreateAccountAsync(account);
            return CreatedAtAction(nameof(GetAccount), new { id = created.Id }, created);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAccount(int id, Account updatedAccount)
        {
            var result = await _accountService.UpdateAccountAsync(id, updatedAccount);
            if (!result) return NotFound();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAccount(int id)
        {
            var result = await _accountService.DeleteAccountAsync(id);
            if (!result) return NotFound();
            return NoContent();
        }
    }
}