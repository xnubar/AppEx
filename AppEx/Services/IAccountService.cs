﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppEx.Services
{
    interface IAccountService
    {
        bool LoginControl(string Email, string Password);

    }
}
