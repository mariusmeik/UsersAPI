﻿using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Contracts
{
    public interface IExternalUsersClient
    {
        public Task<List<UserEntity>> GetUsersFromAPIAsync();
    }
}
