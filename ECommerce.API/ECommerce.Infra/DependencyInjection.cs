using ECommerce.Core.RepositoryContracts;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Infra;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services)
    {
        //to do:Add services to the IoC Container
        //Indra services often include data access, caching n other low level components
        services.AddSingleton<IUsersRepository, UsersRepository>();
        return services;
    }
}
