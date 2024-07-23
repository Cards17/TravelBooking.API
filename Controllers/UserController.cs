using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TravelBooking.API.Core.DTOs;
using TravelBooking.API.Data.Services;

namespace TravelBooking.API.Controllers
{
    [Route("api/[action]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserAccountRepository _userAccountRepository;
        private readonly IMapper _mapper;
        public UserController(IUserAccountRepository userAccountRepository, IMapper mapper)
        {
            _userAccountRepository = userAccountRepository;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<UserAccountDto>>> GetUserAccounts()
        {
            return Ok(await _userAccountRepository.GetUserAccounts());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<UserAccountDto>> GetUserAccountById(int id)
        {
            var userAccount = await _userAccountRepository.GetUserAccountById(id);
            if (userAccount == null)
            {
                return NotFound();
            }
            var userAccountDto = _mapper.Map<UserAccountDto>(userAccount);
            return userAccountDto;
        }

        [HttpPost]
        public async Task<IActionResult> AddUserAccount(UserAccountDto userAccountDto)
        {
            await _userAccountRepository.AddUserAccount(userAccountDto);
            return Ok();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateUserAccount(int id, UserAccountDto userAccountDto)
        {
            try
            {
                if (id != userAccountDto.UserAccountId)
                {
                    return BadRequest();
                }

                await _userAccountRepository.UpdateUserAccount(id, userAccountDto);
            }
            catch (DbUpdateConcurrencyException)
            {
                throw;
            }

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUserAccount(int id)
        {
            try
            {
                var userAccount = await _userAccountRepository.GetUserAccountById(id);
                if (userAccount == null)
                {
                    return NotFound();
                }

                 await _userAccountRepository.DeleteUserAccount(id);

            }
            catch (Exception ex)
            {
                throw new Exception($"Error deleting userAccount with ID {id}: {ex.Message}", ex);
            }
            return NoContent();
        }

    }
}
