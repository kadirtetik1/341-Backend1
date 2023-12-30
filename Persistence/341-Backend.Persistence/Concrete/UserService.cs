using _341_Backend.Application.Abstracts;
using _341_Backend.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _341_Backend.Persistence.Concrete
{
    public class UserService : IUserService
    {
        public List<User> GetUsers()

            => new()
               {
                new(){ Id = Guid.NewGuid(), AcademicRole="teacher", CreatedDate=new DateTime(), EMail="123@hotmail.com", Name="Kadir", LastName="Tetik", Password="123", UserName="wolde"},
                new(){ Id = Guid.NewGuid(), AcademicRole="student", CreatedDate=new DateTime(), EMail="123@hotmail.com", Name="Ahmet", LastName="Tetik", Password="123", UserName="wolde"},
                new(){ Id = Guid.NewGuid(), AcademicRole="teacher", CreatedDate=new DateTime(), EMail="123@hotmail.com", Name="Mehmet", LastName="Tetik", Password="123", UserName="wolde"},
               };
        }
    
}
