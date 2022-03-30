using System.Collections.Generic;

namespace SCHOOL_PROJECT_CROSSCUTING.DTO.User
{
    public class LoginResponseDto
    {
        public string Token { get; set; }
        public IEnumerable<LoginUserType> UserType { get; set; }
    }
}
