using System;
using _341_Backend.Application.DTOs;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _341_Backend.Application.Abstracts
{
    public interface ITokenHandler
    {
      DTOs.Token CreateAccessToken(int minutes, Guid userId, string user_name, string fullname, string e_mail, string password, string name, string lastName, string academic_role);
   
    }
}
