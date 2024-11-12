using EGM.AracKiralama.Model.Dtos;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EGM.AracKiralama.Model.Validators
{
    public class LoginDtoValidator:AbstractValidator<LoginDto>
    {
        public LoginDtoValidator()
        {
            RuleFor(x => x.EPosta)
                .NotEmpty().WithMessage("EPosta alanı boş geçilemez")
                .EmailAddress().WithMessage("Geçerli bir Eposta giriniz");
            RuleFor(x => x.Password)
                .NotEmpty().WithMessage("Password alanı boş geçilemez")
                .Length(3, 15).WithMessage("Geçerli uzunulukta olmalıdır");
        }
    }
}
