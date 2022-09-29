using CurrencyExchangeApi.Models;

namespace CurrencyExchangeApi.Services.Interfaces
{
    public interface IUserService
    {
        IEnumerable<ApplicationUserModel> GetAllUsers();

        ApplicationUserModel Create(ApplicationUserModel user);

        //ApplicationUserModel GetById(int id);

        ApplicationUserModel GetByUserName(string userName);
    }
}

