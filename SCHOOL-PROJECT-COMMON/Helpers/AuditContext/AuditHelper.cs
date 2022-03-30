using SCHOOL_PROJECT_DOMAIN.Entities.Audit;
using SCHOOL_PROJECT_DOMAIN.Entities.User;
using System;

namespace SCHOOL_PROJECT_COMMON.Helpers.AuditContext
{
    public static class AuditHelper
    {
        public static LogEntity LogEntityRegister(UserEntity user)
        {
            return new LogEntity
            {
                Id = Guid.NewGuid(),
                LogTime = DateTime.Now,
                TypeName = "Register",
                UserName = user.Email,
                Type = 1
            };
        }

        public static LogEntity LogEntityLogin(UserEntity user)
        {
            return new LogEntity
            {
                Id = Guid.NewGuid(),
                LogTime = DateTime.Now,
                TypeName = "Login",
                UserName = user.Email,
                Type = 2
            };
        }

        public static LogEntity LogEntityWrongPassword(string user)
        {
            return new LogEntity
            {
                Id = Guid.NewGuid(),
                LogTime = DateTime.Now,
                TypeName = "Wrong Password",
                UserName = user,
                Type = 3
            };
        }


    }
}
