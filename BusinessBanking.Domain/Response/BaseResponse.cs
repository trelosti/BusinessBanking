using BusinessBanking.Domain.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessBanking.Domain.Response
{
    public class BaseResponse
    {
        public string Description { get; set; }

        public StatusCode StatusCode { get; set; }

    }
}
