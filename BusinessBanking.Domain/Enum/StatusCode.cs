﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessBanking.Domain.Enum
{
    public enum StatusCode
    {
        OK = 200,
        BadRequest = 400,
        NotFound = 404,
        InternalServerError = 500
    }
}
