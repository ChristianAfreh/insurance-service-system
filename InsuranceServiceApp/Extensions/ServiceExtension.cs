﻿using InsuranceServiceApp.MapperProfiles;
using InsuranceServiceApp.Models.Data;
using InsuranceServiceApp.Repository;
using InsuranceServiceApp.Repository.IRepository;
using InsuranceServiceApp.Services;
using InsuranceServiceApp.Services.IServices;
using InsuranceServiceApp.UnitOfWork;
using InsuranceServiceApp.UnitOfWork.IUnitOfWork;
using Microsoft.EntityFrameworkCore;

namespace InsuranceServiceApp.Extensions
{
    public static class ServiceExtension
    {
        public static void ConfigureSqlContext(this IServiceCollection services, IConfiguration configuration) =>
            services.AddDbContext<InsuranceSystemDBContext>(opts =>
                        opts.UseSqlServer(configuration.GetConnectionString("InsuranceSystemDB")));


        //Add Repositories 
        public static void RegisterRepositories(this IServiceCollection services)
        {
            services.AddScoped<IClientRepository, ClientRepository>();
            services.AddScoped<IVehicleRepository, VehicleRepository>();
            services.AddScoped<IZoneRepository, ZoneRepository>();
            services.AddScoped<IMakeRepository, MakeRepository>();
            services.AddScoped<IModelRepository, ModelRepository>();
            services.AddScoped<ILookUpRepository, LookUpRepository>();
            services.AddScoped<IVehicleTypeRepository, VehicleTypeRepository>();
        }

        //Add UnitsOfWork
        public static void RegisterUnitsOfWork(this IServiceCollection services)
        {
            services.AddScoped<IClientManagementUoW, ClientManagementUoW>();
        }


        //Add Services
        public static void RegisterServices(this IServiceCollection services)
        {
            services.AddScoped<IClientService, ClientService>();
        }

        public static void RegisterMapperProfiles(this IServiceCollection services)
        {
            services.AddAutoMapper(typeof(ApplicationProfile));
            
        }

    }
}
