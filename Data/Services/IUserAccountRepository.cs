using TravelBooking.API.Core.DTOs;

namespace TravelBooking.API.Data.Services
{
    public interface IUserAccountRepository
    {
        Task<IEnumerable<UserAccountDto>> GetUserAccounts();
        Task<UserAccountDto> GetUserAccountById(int id);
        Task AddUserAccount(UserAccountDto userAccount);
        Task UpdateUserAccount(int id, UserAccountDto UserAccountDto);
        Task DeleteUserAccount(int id);
    }
}
