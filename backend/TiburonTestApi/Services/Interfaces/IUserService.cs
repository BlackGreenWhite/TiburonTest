using Microsoft.AspNetCore.Mvc;
using Services.Models;
using Storage.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Services.Interfaces
{
    public interface IUserService:ICRUD<User, UserModel>
    {
        Task<UserModel> GetByIp(string ip);
        UserModel SuperCreate(User user);
    }
}
