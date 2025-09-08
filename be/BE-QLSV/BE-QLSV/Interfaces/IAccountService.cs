using BE_QLSV.Models;

namespace BE_QLSV.Interfaces
{
    public interface IAccountService
    {
        Task<IEnumerable<Account>> GetAllAccountsAsync();
        Task<Account?> GetAccountByIdAsync(Guid id);
        Task<Account> CreateAccountAsync(Account account);
        Task<bool> UpdateAccountAsync(int id, Account updatedAccount);
        Task<bool> DeleteAccountAsync(int id);
    }
}
