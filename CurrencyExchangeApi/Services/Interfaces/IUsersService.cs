using CurrencyExchangeApi.Models;

namespace CurrencyExchangeApi.Services.Interfaces
{
    public interface IUsersService
    {
        IEnumerable<ApplicationUser> GetAllUsers();

        ApplicationUser Create(ApplicationUser user);

        //ApplicationUserModel GetById(int id);

        ApplicationUser GetByUserName(string userName);
    }
}

