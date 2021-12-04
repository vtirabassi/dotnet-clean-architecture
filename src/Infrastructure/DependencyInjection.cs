﻿using System;
using Application.Intefaces;
using Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            if (!Boolean.TryParse(configuration.GetConnectionString("UseDbInMemory"), out bool result))
                services.AddDbContext<AppDbContext>(options => options.UseInMemoryDatabase("TestDB"));
            else
                throw new NotImplementedException("DB Configuration not implemeted");


            services.AddTransient<ITodoItemRepository, TodoItemRepository>();
            services.AddTransient<IUnitOfWork, UnitOfWork>();


            return services;
        }
    }
}

