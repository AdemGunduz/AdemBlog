using EntityLayer.Concrate;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
    public class WriterValidator : AbstractValidator<Writer>
    {
        public WriterValidator()
        {
            RuleFor(x => x.WriterName).NotEmpty().WithMessage("yazar adı soyadı boş olmaz");
            RuleFor(x => x.WriterMail).NotEmpty().WithMessage("mail boş geçilmez");
            RuleFor(x => x.WriterPassword).NotEmpty().WithMessage("şifre boş olmaz");
            RuleFor(x => x.WriterName).MinimumLength(2).WithMessage("en az iki karakter gerekli");
            RuleFor(x => x.WriterName).MaximumLength(50).WithMessage("en fazla 50 karakter");
        }
    }
}
