using DataAccess.Repositories;
using Domain.Repositories.Interfaces;
using Rating.Models;
using System;
using System.Web.Security;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;

namespace Rating.Providers
{
    public class CustomMembershipProvider: MembershipProvider
    {
        private IUserRepository _userRepository;
        private IRoleRepository _roleRepository;

        public CustomMembershipProvider()
        {
            _userRepository = DependencyResolver.Current.GetService<IUserRepository>();
            _roleRepository = DependencyResolver.Current.GetService<IRoleRepository>();
        }

        public  override bool ValidateUser(string email, string password)
        {
            bool isValid = false;
            UserModel user = UserModel.FromDomainModel(_userRepository.GetUserByEmail(email));
            try 
            {
                if (user != null &&  user.Password == password)
                    {
                        isValid = true; 
                    }
                }
                catch
                {
                    isValid = false; 
                }
         
            return isValid;
        }

        private UserModel CreateUser(string Email, string Password) 
        {
            UserModel user = GetUser(Email);
            if (user == null) 
            {
                UserModel newUser = new UserModel();
                newUser.Email = Email;
                newUser.Password = Password;
                if (RoleModel.FromDomainModel(_roleRepository.GetRole(1)) != null) 
                {
                    newUser.RoleId = 1;
                }
                _userRepository.Add(newUser.ToDomainModel());
                return newUser;

            }
            else
            {
                throw new InvalidOperationException("User already exists!");
            }
        }
   
        //public override string ApplicationName
        //{
        //    get
        //    {
        //        throw new NotImplementedException();
        //    }
        //    set
        //    {
        //        throw new NotImplementedException();
        //    }
        //}

        //public override bool ChangePassword(string username, string oldPassword, string newPassword)
        //{
        //    throw new NotImplementedException();
        //}

        //public override bool ChangePasswordQuestionAndAnswer(string username, string password, string newPasswordQuestion, string newPasswordAnswer)
        //{
        //    throw new NotImplementedException();
        //}


        public override string ApplicationName
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        public override bool ChangePassword(string username, string oldPassword, string newPassword)
        {
            throw new NotImplementedException();
        }

        public override bool ChangePasswordQuestionAndAnswer(string username, string password, string newPasswordQuestion, string newPasswordAnswer)
        {
            throw new NotImplementedException();
        }

        public override MembershipUser CreateUser(string username, string password, string email, string passwordQuestion, string passwordAnswer, bool isApproved, object providerUserKey, out System.Web.Security.MembershipCreateStatus status)
        {
            status = MembershipCreateStatus.Success;
            var user = this.CreateUser(username, password);
            return new MembershipUser("CustomMembershipProvider", user.Email, null, null, null, null,
                      false, false, DateTime.Now, DateTime.MinValue, DateTime.MinValue, DateTime.MinValue, DateTime.MinValue);
        }

        public override bool DeleteUser(string username, bool deleteAllRelatedData)
        {
            throw new NotImplementedException();
        }

        public override bool EnablePasswordReset
        {
            get { throw new NotImplementedException(); }
        }

        public override bool EnablePasswordRetrieval
        {
            get { throw new NotImplementedException(); }
        }

        public override System.Web.Security.MembershipUserCollection FindUsersByEmail(string emailToMatch, int pageIndex, int pageSize, out int totalRecords)
        {
            throw new NotImplementedException();
        }

        public override System.Web.Security.MembershipUserCollection FindUsersByName(string usernameToMatch, int pageIndex, int pageSize, out int totalRecords)
        {
            throw new NotImplementedException();
        }

        public override System.Web.Security.MembershipUserCollection GetAllUsers(int pageIndex, int pageSize, out int totalRecords)
        {
            throw new NotImplementedException();
        }

        public override int GetNumberOfUsersOnline()
        {
            throw new NotImplementedException();
        }

        public override string GetPassword(string username, string answer)
        {
            throw new NotImplementedException();
        }

        public override System.Web.Security.MembershipUser GetUser(string username, bool userIsOnline)
        {
            throw new NotImplementedException();
        }

        public override System.Web.Security.MembershipUser GetUser(object providerUserKey, bool userIsOnline)
        {
            throw new NotImplementedException();
        }

        private  UserModel GetUser(string email)
        {
            return UserModel.FromDomainModel(_userRepository.GetUserByEmail(email));

        }

        public override string GetUserNameByEmail(string email)
        {
            throw new NotImplementedException();
        }

        public override int MaxInvalidPasswordAttempts
        {
            get { throw new NotImplementedException(); }
        }

        public override int MinRequiredNonAlphanumericCharacters
        {
            get { throw new NotImplementedException(); }
        }

        public override int MinRequiredPasswordLength
        {
            get { throw new NotImplementedException(); }
        }

        public override int PasswordAttemptWindow
        {
            get { throw new NotImplementedException(); }
        }

        public override System.Web.Security.MembershipPasswordFormat PasswordFormat
        {
            get { throw new NotImplementedException(); }
        }

        public override string PasswordStrengthRegularExpression
        {
            get { throw new NotImplementedException(); }
        }

        public override bool RequiresQuestionAndAnswer
        {
            get { throw new NotImplementedException(); }
        }

        public override bool RequiresUniqueEmail
        {
            get { throw new NotImplementedException(); }
        }

        public override string ResetPassword(string username, string answer)
        {
            throw new NotImplementedException();
        }

        public override bool UnlockUser(string userName)
        {
            throw new NotImplementedException();
        }

        public override void UpdateUser(System.Web.Security.MembershipUser user)
        {
            throw new NotImplementedException();
        }
    }
}