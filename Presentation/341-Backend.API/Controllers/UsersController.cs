using _341_Backend.Application.Abstracts;
using _341_Backend.Application.DTOs;
using _341_Backend.Application.Repository.UserRepository;
using _341_Backend.Application.ViewModels.User;
using _341_Backend.Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Xml.Linq;

namespace _341_Backend.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {

        readonly private IUserReadRepository _userReadRepository;
        readonly private IUserWriteRepository _userWriteRepository;
        readonly ITokenHandler _tokenHandler;

        public UsersController(IUserReadRepository userReadRepository, IUserWriteRepository userWriteRepository, ITokenHandler tokenHandler)
        {
            _userReadRepository = userReadRepository;
            _userWriteRepository = userWriteRepository;
            _tokenHandler = tokenHandler;
        }

        [HttpGet]

        public async Task<IActionResult> Get(string id)
        {
            return Ok(await _userReadRepository.GetByIdAsync(id, false));
        }


        [HttpPost]
        public async Task<IActionResult> Post(Vm_User_Create model)
        {
            User user = new()
            {
                Name = model.Name,
                LastName = model.LastName,
                UserName = model.UserName,
                Password = model.Password,
                EMail = model.EMail,
                AcademicRole = model.AcademicRole,
    
            };
            await _userWriteRepository.AddAsync(user);

            await _userWriteRepository.SaveAsync();

            return Ok(user);

        }


        [HttpPost("userControl")]
        public async Task<ActionResult<string>> userControl(Vm_User_Control model)
        {

            string error = "Kullanıcı adı veya şifre hatalı!";

            //Response.Headers.Add("Custom-Header", "Custom-Value");


            User user2 = await _userReadRepository.GetWhere(user => user.UserName.Equals(model.UserName)).FirstOrDefaultAsync(); //username'i eşit olan varsa getir
            if (user2 == null || user2.Password != model.Password)
            {

                return Ok(error);
            }

            else  //Başarılı
            {
                string fullname = user2.Name + " " + user2.LastName;

                Token token = _tokenHandler.CreateAccessToken(30, user2.Id, user2.UserName, fullname, user2.EMail, user2.Password, user2.Name, user2.LastName, user2.AcademicRole );
   
                return Ok(token); 
               
            }


        }

        [HttpPut]
        public async Task<IActionResult> Put(Vm_User_Update model)
        {
            string success = "Güncellendi";
            User user = await _userReadRepository.GetByIdAsync(model.Id);

            user.Name = model.Name;
            user.LastName = model.LastName;
            user.UserName = model.UserName;
            user.Password = model.Password;
            user.EMail = model.EMail;
            user.AcademicRole = model.AcademicRole;

            await _userWriteRepository.SaveAsync();

            return Ok(success);
        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            await _userWriteRepository.RemoveAsync(id);
            await _userWriteRepository.SaveAsync();
            return Ok();
        }




    }
}
