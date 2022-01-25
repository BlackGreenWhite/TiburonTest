using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Services.Interfaces;
using Services.Mappings;
using Services.Models;
using Storage;
using Storage.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class UserService : IUserService
    {

        private readonly TiburonTestApiContext _tiburonTestApiContext;

        public UserService(TiburonTestApiContext tiburonTestApiContext)
        {
            _tiburonTestApiContext = tiburonTestApiContext;
        }
        public async Task<UserModel> Create(User user)
        {
            var exister = _tiburonTestApiContext.Users.FirstOrDefault(x => x.UserIP == user.UserIP);
            if (exister == null)
            {
                await _tiburonTestApiContext.Users.AddAsync(user);
                await _tiburonTestApiContext.SaveChangesAsync();
            }
            exister = _tiburonTestApiContext.Users.FirstOrDefault(x => x.UserIP == user.UserIP);

            return exister.ToModel();
        }

        public UserModel SuperCreate(User user)
        {
            _tiburonTestApiContext.Users.Add(user);
            _tiburonTestApiContext.SaveChanges();
            return user.ToModel();  
        }

        public async Task<UserModel> Delete(User user)
        {
            var exister = _tiburonTestApiContext.Users?.FirstOrDefault(x => x.Id == user.Id);
            if (exister != null)
            {
                _tiburonTestApiContext.Users.Remove(exister);
                await _tiburonTestApiContext.SaveChangesAsync();
                return exister.ToModel();
            }
            return null;
        }

        public async Task<IReadOnlyCollection<UserModel>> GetAll()
        {
            var users = await _tiburonTestApiContext.Users
                .Select(x => x.ToModel())
                .ToArrayAsync();
            return users;
        }

        public async Task<UserModel> GetById(long id)
        {
            var user = await _tiburonTestApiContext.Users
                            .FirstOrDefaultAsync(x => x.Id == id);
            return user.ToModel();
        }

        public async Task<UserModel> Update(User user)
        {
            var exister = _tiburonTestApiContext.Users.FirstOrDefault(x => x.Id == user.Id);
            if (exister != null)
            {
                exister.UserIP = user.UserIP;
                await _tiburonTestApiContext.SaveChangesAsync();
                return exister.ToModel();
            }
            return null;
        }

        public async Task<UserModel> GetByIp(string ip)
        {
            var user = await _tiburonTestApiContext.Users
                            .FirstOrDefaultAsync(x => x.UserIP == ip);
            return user.ToModel();
        }
    }
}
