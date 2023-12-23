using Business.Constant;
using Entity.Concretes;
using Entity.Requests;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Business.ValidationRules.FluentValidation
{
    public class AddActivityValidator : AbstractValidator<AddActiviteRequest>
    {
        public AddActivityValidator()
        {
            RuleFor(activity => activity.Type).NotEmpty().WithMessage(Messages.NotEmptyActiviteInfo);
            RuleFor(activity => activity.Note).NotEmpty().WithMessage(Messages.NotEmptyActiviteInfo);
            RuleFor(activity => activity.PetId).NotEmpty().WithMessage(Messages.NotEmptyActiviteInfo);
            RuleFor(activity=>activity.Type).Must(ControlType).WithMessage(Messages.InvalidActiviteType);
        }

        //Control Type
        private bool ControlType(string arg)
        {
            Regex regex = new Regex(@"^[A-ZİĞÜŞÖÇ][a-zA-ZğüşöçıİĞÜŞÖÇ]*$");
            var result = regex.Match(arg);
            if (result.Success)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
