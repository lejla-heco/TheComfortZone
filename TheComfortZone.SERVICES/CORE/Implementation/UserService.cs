using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheComfortZone.DTO.Role;
using TheComfortZone.DTO.User;
using TheComfortZone.DTO.Utils;
using TheComfortZone.SERVICES.API;
using TheComfortZone.SERVICES.CORE.Utils;
using TheComfortZone.SERVICES.DAO;
using TheComfortZone.SERVICES.DAO.Model;

namespace TheComfortZone.SERVICES.CORE.Implementation
{
    public class UserService : BaseCRUDService<UserResponse, User, BaseSearchObject, UserUpsertRequest, UserUpsertRequest>, IUserService
    {
        public UserService(TheComfortZoneContext context, IMapper mapper) : base(context, mapper)
        {
        }

        public override IQueryable<User> IncludeList(IQueryable<User> query)
        {
            return query.Include("Role");
        }

        public override void BeforeInsert(UserUpsertRequest insert, User entity)
        {
            var passwordSalt = PasswordGenerator.GenerateSalt();
            var passwordHash = PasswordGenerator.GenerateHash(passwordSalt, insert.Password);
            entity.PasswordSalt = passwordSalt;
            entity.PasswordHash = passwordHash;
        }

        public async Task<UserResponse> Login(string username, string password)
        {
            var entity = context.Users.Include("Role").FirstOrDefault(x => x.Username == username);
            if (entity == null)
            {
                return null;
            }

            var hash = PasswordGenerator.GenerateHash(entity.PasswordSalt, password);

            if (hash != entity.PasswordHash)
            {
                return null;
            }

            return mapper.Map<UserResponse>(entity);
        }

        public async Task<string> GetUserRole(string username, string password)
        {
            UserResponse currentUser = await Login(username, password);
            return currentUser.UserType;
        }
    }
}
