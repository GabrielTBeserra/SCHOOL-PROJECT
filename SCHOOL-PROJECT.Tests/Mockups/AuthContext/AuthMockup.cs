using MockQueryable.Moq;
using Moq;
using SCHOOL_PROJECT_COMMON.Helpers.ConvertContext;
using SCHOOL_PROJECT_CROSSCUTING.DTO.User;
using SCHOOL_PROJECT_DOMAIN.Entities.Audit;
using SCHOOL_PROJECT_DOMAIN.Entities.User;
using SCHOOL_PROJECT_INFRASTRUCTURE.UnitOfWork.User.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace SCHOOL_PROJECT.Tests.Mockups.AuthContext
{
    public class AuthMockup
    {
        public Mock<IAuthUnitOfWork> CreateMock()
        {
            var mock = new Mock<IAuthUnitOfWork>();

            List<UserEntity> userLista = UserList();
            Mock<IQueryable<UserEntity>> queryUser = userLista.AsQueryable().BuildMock();

            List<LogEntity> logEntities = new List<LogEntity>();
            Mock<IQueryable<LogEntity>> logEntity = logEntities.AsQueryable().BuildMock();
            
            mock.Setup(x => x.UserRepository.GetAllReadOnly()).Returns(queryUser.Object);
            mock.Setup(x => x.LogRepository.GetAllReadOnly()).Returns(logEntity.Object);


            return mock;
        }


        public LoginDto LoginDto()
        {
            return new LoginDto
            {
                Email = It.IsAny<string>(),
                Password = It.IsAny<string>(),
            };
        }

        public RegisterDto RegisterDto()
        {
            return new RegisterDto
            {
                Email = It.IsAny<string>(),
                Password = It.IsAny<string>(),
                LastName = It.IsAny<string>(),
                Name = It.IsAny<string>(),
            };
        }

        public List<UserEntity> UserList()
        {
            var list = new List<UserEntity>();

            var user = new UserEntity
            {
                Email = "teste@teste.com",
                Password = "123".ToSha256(),
                Id = 1,
                LastName = "teste",
                Name = "teste"
            };

            list.Add(user);

            return list;
        }

    }
}
