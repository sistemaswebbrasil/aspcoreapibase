using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Base.Models;

namespace Core.Models {
    public class EmailUserUniqueAttribute : ValidationAttribute {
        protected override ValidationResult IsValid (
            object value, ValidationContext validationContext) {
            var _context = (AppDbContext) validationContext.GetService (typeof (AppDbContext));
            var entity = _context.Users.SingleOrDefault (e => e.Email == value.ToString ());

            if (entity != null) {
                return new ValidationResult (GetErrorMessage (value.ToString ()));
            }
            return ValidationResult.Success;
        }

        public string GetErrorMessage (string email) => $"Email {email} is already in use.";
    }

    public class UsernameUserUniqueAttribute : ValidationAttribute {
        protected override ValidationResult IsValid (
            object value, ValidationContext validationContext) {

            if (value == null)
                return ValidationResult.Success;

            var _context = (AppDbContext) validationContext.GetService (typeof (AppDbContext));
            var entity = _context.Users.SingleOrDefault (e => e.Username == value.ToString ());

            if (entity != null) {
                return new ValidationResult (GetErrorMessage (value.ToString ()));
            }
            return ValidationResult.Success;
        }

        public string GetErrorMessage (string username) => $"User name {username} is already in use.";
    }
}
