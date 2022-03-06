using Data.Repositry;
using Domain.Comands;
using Domain.Handler;
using Domain.Interfaces;
using Domain.Models;
using Domain.Queries;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System.Collections.Generic;

namespace Infrastructure
{
    public class DependencyContainer
    {
        public static void RegisterServices(IServiceCollection services)
        {
            services.AddTransient<IGenericRepository<User>, Repository<User>>();
            services.AddTransient<IGenericRepository<Role>, Repository<Role>>();
            services.AddTransient<IGenericRepository<RoleOfUser>, Repository<RoleOfUser>>();
           

            services.AddTransient<IRequestHandler<GetAllGenericQuery<User>, IEnumerable<User>>, GetAllGenericHandler<User>>();
            services.AddTransient<IRequestHandler<GetAllGenericQuery<RoleOfUser>, IEnumerable<RoleOfUser>>, GetAllGenericHandler<RoleOfUser>>();
            services.AddTransient<IRequestHandler<PostId<User>, User>, PostIdGenericHandler<User>>();
            services.AddTransient<IRequestHandler<DeleteGeneric<User>,string>, DeleteGenericHandler<User>>();
            services.AddTransient<IRequestHandler<PutGeneric<User>, string>, PutGenericHandler<User>>();
            services.AddTransient<IRequestHandler<GetGenericQueryById<User>, User>, GetByidHandler<User>>();


            services.AddTransient<IRequestHandler<GetGenericQueryById<Role>, Role>, GetByidHandler<Role>>();
            services.AddTransient<IRequestHandler<PutGeneric<Role>, string>, PutGenericHandler<Role>>();
            services.AddTransient<IRequestHandler<PostId<Role>, Role>, PostIdGenericHandler<Role>>();
            services.AddTransient<IRequestHandler<GetAllGenericQuery<Role>, IEnumerable<Role>>, GetAllGenericHandler<Role>>();
            services.AddTransient<IRequestHandler<DeleteGeneric<Role>, string>, DeleteGenericHandler<Role>>();



            services.AddTransient<IRequestHandler<PostId<RoleOfUser>,RoleOfUser>, PostIdGenericHandler<RoleOfUser>>();
        }
    }
}