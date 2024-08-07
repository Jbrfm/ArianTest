using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Exceptions.Base;

namespace Application.Exceptions
{
    public class BadRequestException : BaseException
    {
        public BadRequestException(string message, string? mesageStatus = null) : base(message, mesageStatus)
        {
        }
    }
}
