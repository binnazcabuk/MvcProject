using Entity.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.ValidationRules
{
  public  class CategoryValidator:AbstractValidator<Category>
    {
        public CategoryValidator()
        {
            RuleFor(x => x.CategoryName).NotEmpty();
            RuleFor(x => x.CategoryDescription).NotEmpty();
            RuleFor(x => x.CategoryName).MinimumLength(3);
            RuleFor(x => x.CategoryName).MaximumLength(20);


        }

    }
}
