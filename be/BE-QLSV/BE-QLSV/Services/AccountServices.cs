using BE_QLSV.Data;
using BE_QLSV.Interfaces;
using BE_QLSV.Models;
using Microsoft.EntityFrameworkCore;
using System;

namespace BE_QLSV.Services
{
    public class AccountService : IAccountService
    {
        private readonly StudentManagerDbContext _context;

        public AccountService(StudentManagerDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Account>> GetAllAccountsAsync()
        {
            return await _context.Accounts.ToListAsync();
        }

        public async Task<Account?> GetAccountByIdAsync(int id)
        {
            return await _context.Accounts.FindAsync(id);
        }

        public async Task<Account> CreateAccountAsync(Account account)
        {
            account.CreatedAt = DateTime.Now;
            _context.Accounts.Add(account);
            await _context.SaveChangesAsync();
            return account;
        }

        public async Task<bool> UpdateAccountAsync(int id, Account updatedAccount)
        {
            var account = await _context.Accounts.FindAsync(id);
            if (account == null) return false;

            account.Username = updatedAccount.Username;
            account.Email = updatedAccount.Email;
            account.Role = updatedAccount.Role;

            if (!string.IsNullOrWhiteSpace(updatedAccount.PasswordHash))
            {
                account.PasswordHash = updatedAccount.PasswordHash;
            }

            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteAccountAsync(int id)
        {
            var account = await _context.Accounts.FindAsync(id);
            if (account == null) return false;

            _context.Accounts.Remove(account);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}