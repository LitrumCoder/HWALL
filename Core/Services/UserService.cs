using UserRegistrationApp.Core.Interfaces;
using UserRegistrationApp.Core.Models;
using UserRegistrationApp.Core.Exceptions;
using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System.Linq;

namespace UserRegistrationApp.Core.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _repository;

        public event Action<User> OnUserCreated;

        public UserService(IUserRepository repository)
        {
            _repository = repository;
        }

        public void RegisterUser(User user)
        {
            ValidateUser(user);

            OnUserCreated?.Invoke(user);

            if (user.IsAdult)
            {
                _repository.Save(user);
            }
        }

        private void ValidateUser(User user)
        {
            var validationResults = new List<ValidationResult>();
            var context = new ValidationContext(user);

            if (!Validator.TryValidateObject(user, context, validationResults, true))
            {
                throw new ValidationException(
                    string.Join(Environment.NewLine,
                    validationResults.Select(r => r.ErrorMessage)));
            }
        }
    }
}