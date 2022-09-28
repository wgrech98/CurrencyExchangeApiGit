using System;
using CurrencyExchangeApi.Models;

namespace CurrencyExchangeApi.Services.Interfaces
{
    public interface IUserService
    {
        IEnumerable<UserModel> GetAllUsers();

        UserModel Create(UserModel user);

        UserModel GetById(int id);

        UserModel GetByUserName(string userName);
    }
}

