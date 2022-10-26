
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using HusVaskeIdeBackend.Models.User;
using Microsoft.AspNetCore.Cors;

namespace HusVaskeIdeBackend.Controllers

{
    [ApiController]
    public class UsersController : ControllerBase
    {

        private readonly ILogger<UsersController> _logger;

        static readonly IUserRepository repository = new UserRepository();

        public UsersController(ILogger<UsersController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        [Route("api/users")]
        public IEnumerable<UserModel> GetAllUsers()
        {
            return repository.GetAll();
        }

        [HttpPost]
        [Route("api/user")]
        [Consumes("application/json")]
        public UserModel PostUser(UserModel item)
        {

            return repository.Add(item);
        }


    }
}