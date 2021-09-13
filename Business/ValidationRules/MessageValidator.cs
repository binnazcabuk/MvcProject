using Entity.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.ValidationRules
{
   public class MessageValidator:AbstractValidator<Message>
    {
        public MessageValidator()
        {
            RuleFor(x => x.ReceiverMail).NotEmpty().WithMessage("Alıcı adresi boş olamaz!");
            RuleFor(x => x.ReceiverMail).MinimumLength(3).WithMessage("Alıcı Adı en az 3 karakter olmalıdır!");
            
            RuleFor(x => x.ReceiverMail).EmailAddress();
            RuleFor(x => x.SenderMail).EmailAddress();
            RuleFor(x => x.Subject).NotEmpty().WithMessage("Konu Adı boş olamaz!");
            RuleFor(x => x.Subject).MinimumLength(3).WithMessage("Konu Adı en az 3 karakter olmalıdır!");
        }
    }
        
}
