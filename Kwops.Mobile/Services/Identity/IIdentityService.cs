﻿using IdentityModel.OidcClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kwops.Mobile.Services.Identity
{
    public interface IIdentityService
    {
        Task<ILoginResult> LoginAsync();
    }
}
