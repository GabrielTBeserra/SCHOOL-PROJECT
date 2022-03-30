using Moq;
using SCHOOL_PROJECT.Tests.Mockups.AuthContext;
using SCHOOL_PROJECT_CROSSCUTING.DTO.User;
using SCHOOL_PROJECT_SERVICE.ApplicationService.Modules.Auth;
using SCHOOL_PROJECT_SERVICE.ApplicationService.Modules.Config.Interfaces;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace SCHOOL_PROJECT.Tests.Modules.AuthContext
{
    public class UserAuthTest
    {
        AuthMockup _mocks = new AuthMockup();
        CancellationToken ct = new CancellationToken();

        public UserAuthTest()
        {
        }

        [Fact]
        public async Task CreateUser()
        {
            var mock = _mocks.CreateMock();

            var token = new Mock<ITokenApplicationService>();
            var service = new Mock<AuthApplicationService>(mock.Object, token.Object);
            

            var atividadeCargoMock = _mocks.RegisterDto();
            atividadeCargoMock.Email = "teste2@gmail.com";
            atividadeCargoMock.LastName = "teste";
            atividadeCargoMock.Name = "teste";
            atividadeCargoMock.Password = "teste";


            await service.Object.Register(atividadeCargoMock, ct);
            mock.Verify(x => x.CommitAsync(), Times.Once);
        }
        

        public async Task LoginUser()
        {
            var mock = _mocks.CreateMock();
            var teste = new Mock<ITokenApplicationService>();


            var service = new Mock<AuthApplicationService>(mock.Object, teste.Object);


            var atividadeCargoMock = _mocks.LoginDto();
            atividadeCargoMock.Email = "teste@teste.com";
            atividadeCargoMock.Password = "123";


            var resp = await service.Object.Login(atividadeCargoMock, ct);
            Assert.Equal(It.IsAny<LoginResponseDto>(), resp);
        }
    }
}
