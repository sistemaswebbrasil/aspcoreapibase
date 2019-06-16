using System.ComponentModel.DataAnnotations;
using System.Linq;
using Base.Models;

namespace Core.Models
{
    /// <summary>
    /// Validating if email is unique
    /// </summary>
    public class EmailUserUniqueAttribute : ValidationAttribute
    {
        /// <summary>
        /// validate logic
        /// </summary>
        /// <param name="value">Email Text</param>
        /// <param name="validationContext">Context Validation</param>
        /// <returns>ValidationResult</returns>
        protected override ValidationResult IsValid(
            object value, ValidationContext validationContext)
        {
            var user = (User)validationContext.ObjectInstance;
            var _context = (AppDbContext)validationContext.GetService(typeof(AppDbContext));
            var entity = _context.Users.SingleOrDefault(e => e.Email == user.Email && e.Id != user.Id);

            if (entity != null)
            {
                return new ValidationResult(GetErrorMessage(user.Email));
            }
            return ValidationResult.Success;
        }

        /// <summary>
        /// Show Message Error
        /// </summary>
        /// <param name="email">Email Text</param>
        /// <returns></returns>
        public string GetErrorMessage(string email) => $"Email {email} is already in use.";
    }

    /// <summary>
    /// Validating if user name is unique
    /// </summary>
    public class UsernameUserUniqueAttribute : ValidationAttribute
    {
        /// <summary>
        /// Validate logic
        /// </summary>
        /// <param name="value">User Name Text</param>
        /// <param name="validationContext">Context Validation</param>
        /// <returns>ValidationResult</returns>
        protected override ValidationResult IsValid(
            object value, ValidationContext validationContext)
        {
            var user = (User)validationContext.ObjectInstance;

            var _context = (AppDbContext)validationContext.GetService(typeof(AppDbContext));
            var entity = _context.Users.SingleOrDefault(e => e.Username == user.Username && e.Id != user.Id);

            if (entity != null)
            {
                return new ValidationResult(GetErrorMessage(user.Username));
            }
            return ValidationResult.Success;
        }

        /// <summary>
        /// Validating if user name is unique
        /// </summary>
        public string GetErrorMessage(string username) => $"User name {username} is already in use.";
    }
}
