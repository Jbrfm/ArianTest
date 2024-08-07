using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.DTOs.Users;
using FluentValidation;
using Application.Validators.Messages;

namespace Application.Validators
{
    public class UserValidator : AbstractValidator<CreateUserDto>
    {
        public UserValidator()
        {
            RuleFor(user => user.Email)
                .NotNull().WithMessage(ValidationMessages.Email)
                .EmailAddress().WithMessage(ValidationMessages.EmailFormat);
            
            //password lenght must be fixed later
            RuleFor(user => user.Password)
                .NotNull().WithMessage(ValidationMessages.Password)
                .MinimumLength(4).WithMessage(ValidationMessages.PasswordMin);
            
            RuleFor(user => user.Username)
                .NotNull().WithMessage(ValidationMessages.UserName)
                .MinimumLength(4).WithMessage(ValidationMessages.UserNameMin)
                .MaximumLength(100).WithMessage(ValidationMessages.UserNameMax);
        }
    }
}
