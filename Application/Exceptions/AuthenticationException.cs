using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Exceptions.Base;

namespace Application.Exceptions
{
    public class AuthenticationException : BaseException
    {
        public AuthenticationException(string message, string? mesageStatus = null) : base(message, mesageStatus)
        {
        }
    }
}
