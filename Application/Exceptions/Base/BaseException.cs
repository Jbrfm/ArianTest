using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Exceptions.Base
{
    public class BaseException : ApplicationException
    {
        public BaseException(string message, string? mesageStatus = null) : base(message)
        {
            ExceptionResponse = new ExceptionResponse
            {
                ExceptionMessage = message,
                //RedirectTo = redirectTo,
                ExceptionMessageStatus = mesageStatus ?? ExceptionMessageStatus.ERROR
            };
        }

        public ExceptionResponse ExceptionResponse { get; set; }
    }
}
