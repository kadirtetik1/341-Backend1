using _341_Backend.Application.Repository.UserRepository;
using _341_Backend.Domain.Entities;
using _341_Backend.Persistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _341_Backend.Persistence.Repository.UserRepository
{
    public class UserWriteRepository : WriteRepository<User>, IUserWriteRepository
    {
        public UserWriteRepository(_341DbContext context) : base(context)
        {

        }
    }
}
