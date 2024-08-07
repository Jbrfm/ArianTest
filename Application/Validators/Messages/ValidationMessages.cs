using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Validators.Messages
{
    public static class ValidationMessages
    {
        #region User
        public const string Email = "لطفا ایمیل را وارد کنید";
        public const string EmailFormat = "ایمیل را صحیح وارد کنید";
        public const string Password = "لطفا رمز را وارد کنید";
        public const string PasswordMin = "رمز کوتاه است";
        public const string PhoneNumber = "لطفا شماره همراه را وارد کنید";
        public const string PhoneNumberFormat = "شماره همراه صحیح نیست";
        public const string UserName = "لطفا نام کاربری را وارد کنید";
        public const string UserNameMin = "نام کاربری کوتاه است";
        public const string UserNameMax = "نام کاربری طولانی است";
        #endregion
    }
}
