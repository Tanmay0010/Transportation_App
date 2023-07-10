using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using UsersLibrary.Repositories;
using UsersLibrary;
using UsersLibrary.Entities;
using UsersLibrary.Contracts;


namespace UserLogin.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
            private readonly IUserContract _userRepository = null;

            public UserController(IUserContract userRepository)
            {
                _userRepository = userRepository;
            }

            [HttpPost, Route("Register")]
            public IActionResult Register(Users user)
            {
                try
                {
                    _userRepository.Register(user);
                    return StatusCode(200, $"{user.Name} has been added");
                }
                catch (Exception ex)
                {

                    return StatusCode(500, ex.Message);
                }
            }

            [HttpPost, Route("Login")]
            public IActionResult Login(Users user)
            {
                #region Validating User
                if (user == null)
                {
                    return BadRequest("Invalid Client Request");
                }
                if (_userRepository.Login(user) == true)
                {
                    string token = GetToken();
                    return StatusCode(200, token);
                }
                return Unauthorized(); //Status 401 Unauthorized Response 
                #endregion
                //return StatusCode(401, "UnAuthorized");
            }
            #region Token Generation Code
            [NonAction]
            public string GetToken()
            {
                var secretKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("superSecretKey@345"));
                var signinCredentials = new SigningCredentials(secretKey, SecurityAlgorithms.HmacSha256);
                var tokeOptions = new JwtSecurityToken(
                    issuer: "https://localhost:5029", //who issue the token //representing the name of the webserver that issues the token
                    audience: "https://localhost:5029", //who use the token //representing valid recipients
                    claims: new List<Claim>(), //list of user roles //user can be an admin, manager, or author
                    expires: DateTime.Now.AddMinutes(5), //set expire time for the token //object that represents the date and time after which the token expires
                    signingCredentials: signinCredentials
                );
                var token = new JwtSecurityTokenHandler().WriteToken(tokeOptions); //generate token using token options
                return token;
            }
            #endregion
        }
}
