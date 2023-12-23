﻿using Business.Constant;
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
    public class AddUserValidator : AbstractValidator<AddUserRequest>
    {
        public AddUserValidator()
        {
            //FirstName
            RuleFor(user => user.FirstName).NotEmpty().WithMessage(Messages.UsersFirstNameNotEmpty);
            RuleFor(user => user.FirstName).Must(ControlName).WithMessage(Messages.InvalidFirstName);
            RuleFor(user => user.FirstName).MinimumLength(2).WithMessage(Messages.LessFirstName);

            // LastName
            RuleFor(user => user.LastName).NotEmpty().WithMessage(Messages.UsersLastNameNotEmpty);
            RuleFor(user => user.LastName).Must(ControlName).WithMessage(Messages.InvalidLastName);
            RuleFor(user => user.LastName).MinimumLength(2).WithMessage(Messages.LessLastName);

            //PhoneNumber
            RuleFor(user => user.PhoneNumber).NotEmpty().WithMessage(Messages.UsersPhoneNumberNotEmpty);
            RuleFor(user => user.PhoneNumber).Must(ControlPhoneNumber).WithMessage(Messages.InvalidPhoneNumber);
            RuleFor(user => user.PhoneNumber).Must(StartWith).WithMessage(Messages.NotStartPhoneNumber);

            //Email
            RuleFor(user => user.Email).NotEmpty().WithMessage(Messages.UsersEmailNotEmpty);
            RuleFor(user => user.Email).Must(ControlEmail).WithMessage(Messages.InvalidEmail);
        }

        //Control Name
        private bool ControlName(string arg)
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

        //Control Email
        private bool ControlEmail(string arg)
        {
            Regex regex = new Regex(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$");
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

        // ControlPhoneNumber
        private bool ControlPhoneNumber(string arg)
        {
            Regex regex = new Regex(@"^[1-9]{10}$");
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

        private bool StartWith(string arg)
        {
            var result = arg.StartsWith("0");
            if (arg.StartsWith("0"))
            {
                return false;
            }
            else
            {
                return true;
            }
        }
    }
}
