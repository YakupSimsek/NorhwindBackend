using Business.Abstract;
using Business.Contansts;
using Core.Entities.Concrete;
using Core.Utilities.Result;
using Core.Utilities.Security.Hassing;
using Core.Utilities.Security.Jwt;
using Entities.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class AuthManager : IAuthSerivice
    {
        IUserService _userSerivice;
        ITokenHelper _tokenHelper;

        public AuthManager(ITokenHelper tokenHelper, IUserService userSerivice)
        {
            _userSerivice = userSerivice;   
            _tokenHelper = tokenHelper;     
        }

        public IDataResult<AccessToken> CreateAccessToken(User user)
        {
            var claims = _userSerivice.GetClaims(user);
           var accesToken =  _tokenHelper.CreateToken(user,claims);
            return new SuccessDataResult<AccessToken>(accesToken, Messages.CreateToken);
        }

        public IDataResult<User> Login(UserForLoginDto userForLoginDto)
        {
            var userToCheck = _userSerivice.GetByMail(userForLoginDto.Email);
            if (userToCheck == null)
            {
                return new ErrorDataResult<User>(Messages.UserNotFound);
                    
            }
            if (!HashingHelper.VerfiyPasswordHas(userForLoginDto.Password,userToCheck.PasswordHash,userToCheck.PasswordSalt))
            {
                return new ErrorDataResult<User>(Messages.PasswordError);
            }
            return new SuccessDataResult<User>(userToCheck);
        }

        public IDataResult<User> Register(UserForRegisterDto userForRegisterDto, string password)
        {
            byte[] passwordHash, passwordSalt;
            HashingHelper.CreatePasswordHas(password, out passwordHash ,out passwordSalt  );
            var user = new User
            {
                Email = userForRegisterDto.Email,
                FirstName = userForRegisterDto.FirstName,
                LastName = userForRegisterDto.LastName,
                PasswordHash = passwordHash,
                PasswordSalt = passwordSalt,
                Status = true
            };
            _userSerivice.Add(user);
            return new SuccessDataResult<User>(user, Messages.RegisterOk);
        }

        public IResult UserExistx(string email)
        {
            if (_userSerivice.GetByMail(email)!=null)
            {
                return new ErrorResult(Messages.UserHave);
            }
            return new SuccessResult();
        }
    }
}
