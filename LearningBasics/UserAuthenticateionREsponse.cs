using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearningBasics
{
    public class UserAuthenticateionResponse
    {

        public bool IsAuthenticated { get; set; }
        public string Message { get; set; }

        public string JWTToken { get; set; }

        public string RefreshToken { get; set; }

        public DateTime RefreshTokenExp { get; set; }
    }
}
