using AutoMapper;
using Microsoft.EntityFrameworkCore;
using TravelBooking.API.Core.DTOs;
using TravelBooking.API.Models;

namespace TravelBooking.API.Data.Services
{
    public class UserAccountRepository : IUserAccountRepository
    {
        private readonly DataContext _dataContext;
        private readonly IMapper _mapper;
        public UserAccountRepository(DataContext dataContext, IMapper mapper)
        {

            _dataContext = dataContext; 
            _mapper = mapper;
        }

        public async Task<IEnumerable<UserAccountDto>> GetUserAccounts()
        {
            var userAccounts = await _dataContext.UserAccounts.ToListAsync();
            return _mapper.Map<IEnumerable<UserAccountDto>>(userAccounts);
        }

        public async Task<UserAccountDto> GetUserAccountById(int id)
        {
            var userAccountById = await _dataContext.UserAccounts.FindAsync(id);
            return _mapper.Map<UserAccountDto>(userAccountById);
        }

        public async Task AddUserAccount(UserAccountDto userAccountDto)
        {
            var userAccount = _mapper.Map<UserAccount>(userAccountDto);
            await _dataContext.UserAccounts.AddAsync(userAccount);
            await _dataContext.SaveChangesAsync();
        }

        public async Task UpdateUserAccount(int id, UserAccountDto UserAccountDto)
        {
            var userAccount = _mapper.Map<UserAccount>(UserAccountDto);
            _dataContext.Entry(userAccount).State = EntityState.Modified;
            await _dataContext.SaveChangesAsync();
        }

        public async Task DeleteUserAccount(int id)
        {
            var userAccount = await _dataContext.UserAccounts.FindAsync(id);
            if (userAccount != null)
            {
                _dataContext.UserAccounts.Remove(userAccount);
                await _dataContext.SaveChangesAsync();
            }
        }
    }
}
