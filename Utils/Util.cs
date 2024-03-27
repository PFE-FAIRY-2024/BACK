using ConsultationBack.dto;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using timsoft.DataBase;
using timsoft.entities;

namespace timsoft.Utils
{
    public class Util : IUtil
    {
        private readonly DataBaseContext _context;
        private readonly IConfiguration _config;

        public Util()
        {
        }

        public Util(DataBaseContext context, IConfiguration config)
        {
            _context = context;
            _config = config;

        }

        public bool verifyPassword(SignIn signIn)
        {

            var user = _context.Users.Where(u => u.Username == signIn.UserName)
                   .FirstOrDefault();
            if (user == null)
            {
                return false;
            }
            string h_pass = HashPassword.HashPass(signIn.Password);

            if (h_pass == user.Password)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool verifyUserName(SignIn signIn)
        {
            var user = _context.Users
                     .Where(u => u.Username == signIn.UserName)
                     .FirstOrDefault();
            if (user == null)
            {
                return false;
            }
            return true;
        }




        public string GenerateToken(SignIn signIn)
        {
           
          
            var user = _context.Users.FirstOrDefault(X=>X.Username == signIn.UserName);
            var roleName = Enum.GetName(typeof(ERole), user.role);
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var tokenHandler = new JwtSecurityTokenHandler();
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                        new Claim(ClaimTypes.Name,user.Username),
                        new Claim(ClaimTypes.Role, roleName)
                }),

                Expires = DateTime.Now.AddDays(2),
                SigningCredentials = credentials
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            var Token = tokenHandler.WriteToken(token);

            return Token;
        }
    }
}
