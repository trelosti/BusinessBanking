using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessBanking.Domain.Exceptions
{
    public class CustomerNotFoundException : Exception
    {
        public CustomerNotFoundException() { }

        public CustomerNotFoundException(string message) : base(message) { }
    }
}
