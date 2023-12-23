using Business.Constant;
using Entity.Concretes;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.ValidationRules.FluentValidation
{
    public class AddFoodValidator : AbstractValidator<Food>
    {
        public AddFoodValidator()
        {
            RuleFor(food => food.Name).NotEmpty().WithMessage(Messages.NotEmptyPetName);
        }
    }
}
