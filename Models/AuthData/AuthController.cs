using System;
using HusVaskeIdeBackend.Models.AuthData;
using HusVaskeIdeBackend.Models.User;
using Microsoft.AspNetCore.Mvc;
using HusVaskeIdeBackend.Models.User.InDto;



namespace HusVaskeIdeBackend.Models.AuthData

{

    public class AuthController : ControllerBase
    {
        private IAuthService _authService;
        private IUserRepository _repository;
        public AuthController(IAuthService authService, IUserRepository repository)
        {
            _authService = authService;
            _repository = repository;
        }

        [HttpPost]
        [Route("api/login")]
        [Consumes("application/json")]
        public ActionResult<AuthData> PostLogin([FromBody] UserInDto model)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var user = _repository.GetSingle(u => u.Email == model.Email);

            if (user == null)
            {
                return BadRequest(new { email = "no user with this email" });
            }

            var passwordValid = _authService.VerifyPassword(model.Password, user.Password);
            if (!passwordValid)
            {
                return BadRequest(new { password = "invalid password" });
            }

            return _authService.GetAuthData(user.Id.ToString(), user.Username);
        }

        [HttpPost]
        [Route("api/register")]
        [Consumes("application/json")]
        public ActionResult<AuthData> PostRegister([FromBody] UserRegisterInDTO model)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var emailUniq = _repository.isEmailUniq(model.Email);
            if (!emailUniq) return BadRequest(new { email = "user with this email already exists" });
            //var usernameUniq = _repository.IsUsernameUniq(model.Username); //want to make it so usernames do not have to be unique
            //if (!usernameUniq) return BadRequest(new { username = "user with this email already exists" });

            var id = Guid.NewGuid().ToString();
            var user = new UserItem
            {
                Id = id,
                Username = model.Username,
                Email = model.Email,
                Password = _authService.HashPassword(model.Password)
            };
            _repository.Add(user);
            _repository.Commit();

            return _authService.GetAuthData(id, model.Username);
        }



    }
}