using Domain.Repositories.Interfaces;
using Rating.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace Rating.Providers
{
    public class CustomRoleProvider : RoleProvider
    {
        private IRoleRepository _roleRepository;
        private IUserRepository _userRepository;
        public CustomRoleProvider()
        {
            _roleRepository = DependencyResolver.Current.GetService<IRoleRepository>();
            _userRepository = DependencyResolver.Current.GetService<IUserRepository>();
        }
        public override string[] GetRolesForUser(string email)
        {
            string[] role = new string[] { };
            try
            {
                UserModel user = UserModel.FromDomainModel(_userRepository.GetUserByEmail(email));
                if (user != null) 
                {
                    RoleModel userRole = RoleModel.FromDomainModel(_roleRepository.GetRole(user.RoleId));
                    if(userRole != null)
                    {
                        role = new string[] { userRole.Name };
                    }
                }
            }
            catch 
            {
                role = new string[] { };
            }
            return role;
            
            // throw new NotImplementedException();
        }

        public override bool IsUserInRole(string email, string roleName)
        {
            bool outputResult = false;
            try 
            {
                UserModel user = UserModel.FromDomainModel(_userRepository.GetUserByEmail(email));
                if (user != null) 
                {
                    RoleModel userRole = RoleModel.FromDomainModel(_roleRepository.GetRole(user.RoleId));
                    if (userRole != null && userRole.Name == roleName)
                    {
                        outputResult = true;
                    }
                }
            }
            catch
            {
                outputResult = false;
            }
            return outputResult;
            //throw new NotImplementedException();
        }
        public override void AddUsersToRoles(string[] usernames, string[] roleNames)
        {
            throw new NotImplementedException();
        }

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

        public override void CreateRole(string roleName)
        {
            throw new NotImplementedException();
        }

        public override bool DeleteRole(string roleName, bool throwOnPopulatedRole)
        {
            throw new NotImplementedException();
        }

        public override string[] FindUsersInRole(string roleName, string usernameToMatch)
        {
            throw new NotImplementedException();
        }

        public override string[] GetAllRoles()
        {
            throw new NotImplementedException();
        }

        

        public override string[] GetUsersInRole(string roleName)
        {
            throw new NotImplementedException();
        }

       

        public override void RemoveUsersFromRoles(string[] usernames, string[] roleNames)
        {
            throw new NotImplementedException();
        }

        public override bool RoleExists(string roleName)
        {
            throw new NotImplementedException();
        }
    }
}