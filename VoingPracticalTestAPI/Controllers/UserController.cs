using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System.Security.Cryptography;
using System.Text;
using VoingPracticalTestAPI.Comman_func;
using VoingPracticalTestAPI.Models;
using VoingPracticalTestData;
using VoingPracticalTestData.Models;

namespace VoingPracticalTestAPI.Controllers
{
    [Route("api/user")]
    [ApiController]
    public class UserController : ControllerBase
    {
        ApplicationContext _dbContext;
        public IMapper _mapper { get; }
        public UserController(IMapper mapper, ApplicationContext dbContext)
        {
            _mapper = mapper;
            _dbContext = dbContext;
        }

        [HttpPost("Register")]
        public IActionResult Register(User_Register register)
        {
            response response = new response();
            try
            {
                if (string.IsNullOrEmpty(register.FullName) || string.IsNullOrEmpty(register.Email) || string.IsNullOrEmpty(register.Password))
                {
                    response.message = "Data is not valid.";
                    return BadRequest(response);
                }
                if (register.FullName.Length < 5)
                {
                    response.message = "Full name must be more than 5 character.";
                    return BadRequest(response);
                }
                if (register.Password.Length < 5)
                {
                    response.message = "Password must be more than 5 character.";
                    return BadRequest(response);
                }

                var fndEmail = _dbContext.UserDetail.Where(e => e.Email == register.Email).Count();
                if (fndEmail == 0)
                {
                    if (comman.ValidateEmailId(register.Email))
                    {
                        _dbContext.Database.BeginTransaction();
                        var add_obj = _mapper.Map<UserDetail>(register);
                        _dbContext.UserDetail.Add(add_obj);
                        int id = _dbContext.SaveChanges();

                        if (id > 0)
                        {
                            UserLogin addLogin = new UserLogin();
                            addLogin.UserId = add_obj.UserId;
                            addLogin.IsBlocked = false;
                            addLogin.IsActive = true;
                            addLogin.LastLoggedOn = DateTime.UtcNow;
                            addLogin.Password = comman.ComputeSha256Hash(register.Password);
                            _dbContext.UserLogin.Add(addLogin);
                            int userlogin_id = _dbContext.SaveChanges();
                            if (userlogin_id > 0)
                            {
                                _dbContext.Database.CommitTransaction();
                                response.data = _mapper.Map<User_Register>(add_obj);
                                response.status_code = 1;
                                response.message = "User register successfully.";
                                return Ok(response);
                            }
                        }
                    }
                }
                else
                {
                    response.message = "Email id already register with us.";
                    response.status_code = 2;
                    return Ok(response);
                }
            }
            catch (Exception ex)
            {
                _dbContext.Database.RollbackTransaction();
            }
            response.status_code = 0;
            response.message = "Somthing went wrong!";
            return Ok(response);
        }



    }
}
