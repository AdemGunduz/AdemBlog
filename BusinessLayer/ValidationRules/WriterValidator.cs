using EntityLayer.Concrate;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
    public class WriterValidator : AbstractValidator<User>
    {
        public WriterValidator()
        {
            RuleFor(x => x.UserName).NotEmpty().WithMessage("yazar adı soyadı boş olmaz");
            RuleFor(x => x.UserMail).NotEmpty().WithMessage("mail boş geçilmez");
            RuleFor(x => x.UserPassword).NotEmpty().WithMessage("şifre boş olmaz");
            RuleFor(x => x.UserName).MinimumLength(2).WithMessage("en az iki karakter gerekli");
            RuleFor(x => x.UserName).MaximumLength(50).WithMessage("en fazla 50 karakter");
        }
    }
}
