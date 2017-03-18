using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using DotnetCoreServer.Models;

namespace DotnetCoreServer.Controllers
{
    [Route("api/[controller]")]
    public class UserController : Controller
    {
        // // GET api/user
        // [HttpGet]
        // public IEnumerable<string> Get()
        // {
        //     return new string[] { "value1", "value2" };
        // }

        // GET api/user/5
        [HttpGet("{id}")]
        public User Get(int id)
        {
            User user = UserDao.GetUser(id);
            return user;
        }

    }
}
