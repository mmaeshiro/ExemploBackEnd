using System;
using ExemploBackEndsRobustos.Domain.Contracts.Services;
using ExemploBackEndsRobustos.Domain.Models;
using ExemploBackEndsRobustos.Domain.Contracts.Repositories;
using ExemploBackEndsRobustos.Common.Validation;
using ExemploBackEndsRobustos.Common.Resources;

namespace ExemploBackEndsRobustos.Business.Services
{

    /*EXECUTAR PACKAGE Install-Package Unity*/

    public class UserService : IUserService
    {

        private IUserRepository _repository;

        public UserService(IUserRepository repository)
        {
            _repository = repository;
        }

        public User Authenticate(string email, string password)
        {
            var user = GetByEmail(email);

            if (user.Password != PassordAssertionConcern.Encrypt(password))
                throw new Exception(Errors.InvalidCredentials);

            return user;

        }

        public void ChangeInformation(string email, string name)
        {
            var user = GetByEmail(email);

            user.ChangeName(name);

            user.Validate();

            _repository.Update(user);
        }

        public void ChangePassword(string email, string password, string newPassword, string confirmNewPassword)
        {
            var user = Authenticate(email, password);

            user.SetPassword(newPassword, confirmNewPassword);
            user.Validate();

            _repository.Update(user);
        }

        public User GetByEmail(string email)
        {
            var user = _repository.Get(email);
            //if (user == null)
            //    throw new Exception(Errors.UserNotFound);

            return user;            
        }

        public void Register(string name, string email, string password, string confirmPassword)
        {
            var hasUser = GetByEmail(email);
            if (hasUser != null)
                throw new Exception(Errors.DuplicateEmail);

            var user = new User(name, email);
            user.SetPassword(password, confirmPassword);
            user.Validate();

            _repository.Create(user);
        }

        public string ResetPassword(string email)
        {
            var user = GetByEmail(email);
            var password = user.ResetPassword();
            user.Validate();

            _repository.Update(user);

            return password;
        }

        public void Dispose()
        {
            _repository.Dispose();
        }
    }
}
