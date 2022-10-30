using Business.Abstract;
using Entities.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Contorolles
{
    [Route(template: "api/[controller]")]
    [ApiController]
    public class AuthController : Controller
    {
        private IAuthSerivice _authSerivice;
        public AuthController(IAuthSerivice authSerivice)
        {
            _authSerivice = authSerivice;
        }

        [HttpPost(template: "login")]
        public ActionResult Login(UserForLoginDto userForLoginDto)
        {
            var userToLogin = _authSerivice.Login(userForLoginDto);
            if (!userToLogin.Success)
            {
                return BadRequest(userToLogin.Message);
            }
            var result = _authSerivice.CreateAccessToken(userToLogin.Data);
            if (result.Success)
            {
                return Ok(result.Data);
            }
            return BadRequest(result.Message);
            
        }

        [HttpPost(template: "register")]
        public ActionResult Regiter(UserForRegisterDto userForRegisterDto)
        {
            var userExists = _authSerivice.UserExistx(userForRegisterDto.Email);

            if (!userExists.Success)
            {
                return BadRequest(userExists.Message);
            }
            var registerResult = _authSerivice.Register(userForRegisterDto, userForRegisterDto.Password);
            var result = _authSerivice.CreateAccessToken(registerResult.Data);
            if (result.Success)
            {
                return Ok(result.Data);
            }
            return BadRequest(result.Message);
        }
    }
}

