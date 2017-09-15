using System;
using ExemploBackEndsRobustos.Common.Validation;
using ExemploBackEndsRobustos.Common.Resources;

namespace ExemploBackEndsRobustos.Domain.Models
{
    public class User
    {
        #region Construtor
        public User()
        {
           
        }

        public User(string name, string email)
        {
            this.Id = Guid.NewGuid();
            this.Name = name;
            this.Email = email;
        }

        #endregion

        #region Properties

        public Guid Id { get; private set; }
        public string Name { get; private set; }
        public string Email { get; private set; }
        public string Password { get; private set; }

        //public string ConfirmPassword { get; private set; }

        #endregion

        #region Methods

        public void SetPassword(string password, string confirmPassoword)
        {
            AssertionConcern.AssertArgumentNotNull(password, Errors.PasswordRequerid);
            AssertionConcern.AssertArgumentNotNull(confirmPassoword, Errors.InvalidPasswordConfirmation);
            AssertionConcern.AssertArgumentEquals(password, confirmPassoword, Errors.PasswordDotNotMatch);
            AssertionConcern.AssertArgumentLength(password, 6, 20, Errors.InvalidPassword);

            this.Password = PassordAssertionConcern.Encrypt(password);
        }

        public string ResetPassword()
        {
            string password = Guid.NewGuid().ToString().Substring(0, 8);
            this.Password = PassordAssertionConcern.Encrypt(password);
            return password;
        }

        public void ChangeName(string name)
        {
            AssertionConcern.AssertArgumentNotNull(name, Errors.NameRequired);
            AssertionConcern.AssertArgumentNotEmpty(name, Errors.NameRequired);

            this.Name = name;
        }

        public void Validate()
        {
            AssertionConcern.AssertArgumentLength(this.Name, 3, 60,Errors.InvalidUserName);
            EmailAssertionConcern.AssertIsValid(this.Email);
            PassordAssertionConcern.AssertIsValid(this.Password);
        }

        #endregion
    }
}






