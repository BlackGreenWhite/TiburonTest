using Services.Models;
using Storage.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Services.Mappings
{
    public static class UserMapping
    {
        public static UserModel ToModel(this User user)
        {
            if (user == null)
            {
                return null;
            }
            var userModel = new UserModel
            {
                Id = user.Id,
                UserIP = user.UserIP
            };
            return userModel;
        }
    }
}
