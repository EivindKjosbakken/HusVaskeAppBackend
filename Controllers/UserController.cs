
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

        [HttpPost]
        [Route("api/user")]
        [Consumes("application/json")]
        public void PostUser(UserItem item)
        {

            Console.WriteLine("funker ikke nå");
        }


    }
}