using System;
using HusVaskeIdeBackend.Models.AuthData;
using HusVaskeIdeBackend.Models.User;
using Microsoft.AspNetCore.Mvc;
using HusVaskeIdeBackend.Models.User.InDto;



namespace HusVaskeIdeBackend.Models.AuthData

{
    public class AuthController : ControllerBase
    {
        AuthService authService;
        IUserRepository userRepository;
        public AuthController(AuthService authService, IUserRepository userRepository)
        {
            this.authService = authService;
            this.userRepository = userRepository;
        }

        [HttpPost]
        [Route("api/login")]
        [Consumes("application/json")]
        public ActionResult<AuthData> PostLogin([FromBody] UserInDto model)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var user = userRepository.GetSingle(u => u.Email == model.Email);

            if (user == null)
            {
                return BadRequest(new { email = "no user with this email" });
            }

            var passwordValid = authService.VerifyPassword(model.Password, user.Password);
            if (!passwordValid)
            {
                return BadRequest(new { password = "invalid password" });
            }

            return authService.GetAuthData(user.Id.ToString());
        }

        [HttpPost]
        [Route("api/register")]
        [Consumes("application/json")]
        public ActionResult<AuthData> PostRegister([FromBody] UserItem model)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var emailUniq = userRepository.isEmailUniq(model.Email);
            if (!emailUniq) return BadRequest(new { email = "user with this email already exists" });
            var usernameUniq = userRepository.IsUsernameUniq(model.Username);
            if (!usernameUniq) return BadRequest(new { username = "user with this email already exists" });

            var id = Guid.NewGuid().ToString();
            var user = new UserItem
            {
                Id = id,
                Username = model.Username,
                Email = model.Email,
                Password = authService.HashPassword(model.Password)
            };
            userRepository.Add(user);
            userRepository.Commit();

            return authService.GetAuthData(id);
        }

    }
}