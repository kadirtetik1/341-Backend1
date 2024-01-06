using _341_Backend.Application.Abstracts;
using _341_Backend.Persistence.Concrete;
using _341_Backend.Persistence.Context;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _341_Backend.Application.Repository.UserRepository;
using _341_Backend.Persistence.Repository.UserRepository;

namespace _341_Backend.Persistence
{
    public static class ServiceRegistration
    {
        public static void AddPersistenceServices(this IServiceCollection services)
        {
            services.AddDbContext<_341DbContext>(options => options.UseNpgsql("User ID=postgres;Password=123456;Host=localhost;Port=5432;Database=CMPE341;"));


            services.AddScoped<IUserReadRepository, UserReadRepository>();
            services.AddScoped<IUserWriteRepository, UserWriteRepository>();
            

        }
    }
}
