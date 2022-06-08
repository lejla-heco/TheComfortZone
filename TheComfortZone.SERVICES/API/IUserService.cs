﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheComfortZone.DTO.User;
using TheComfortZone.DTO.Utils;

namespace TheComfortZone.SERVICES.API
{
    public interface IUserService : ICRUDService<UserResponse, UserSearchRequest, UserInsertRequest, UserUpdateRequest>
    {
        Task<DTO.User.UserResponse> Login(string username, string password);
        Task<LoggedUser> GetUserRole(string username, string password);
        Task<List<UserCmbList>> GetUsernames();
        Task<List<DTO.Charts.SalesResponse>> GetSalesByPeriod(DateTime? fromDate = null, DateTime? toDate = null);
    }
}
