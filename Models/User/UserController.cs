
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Authorization;

namespace HusVaskeIdeBackend.Models.User

{
    [ApiController]
    //[Authorize] //TODO fjerna her, husk å bytte tilbake
    public class UserController : ControllerBase
    {

        private readonly ILogger<UserController> _logger;

        private IUserRepository _repository;

        public UserController(ILogger<UserController> logger, IUserRepository repository)
        {
            _logger = logger;
            _repository = repository;
        }

        [HttpGet]
        [Route("api/users")]
        public IEnumerable<UserItem> GetAllUsers()
        {
            return _repository.GetAll();
        }

        [HttpGet]
        [Route("api/getusername/{id}")]
        public string GetUsernameFromId(string id)
        {
            UserItem user = _repository.GetSingle(id);
            return user.Username;

        }

    }
}