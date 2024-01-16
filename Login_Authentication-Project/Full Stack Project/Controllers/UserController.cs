using Full_Stack_Project.Data_Access_Layer;
using Full_Stack_Project.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Full_Stack_Project.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly FullStackDBContext _dbContext;
        public UserController(FullStackDBContext context)
        {
            _dbContext = context;
        }

        [HttpPost]
        [Route("RegisterUser")]
        public IActionResult RegisterUser(Users user)
        {
            RegisterUser reg = new RegisterUser();
            AuthenticationDL al = new AuthenticationDL(_dbContext);


            reg = al.RegisterDL(user);

            return Ok(reg);
        }


        [HttpPost]
        [Route("Login")]
        public IActionResult Login(LoginUser user)
        {

            LoginUserResponse res = new LoginUserResponse();
            AuthenticationDL al = new AuthenticationDL(_dbContext);
            res = al.LoginDL(user);

            return Ok(res);

        }


    }
}
