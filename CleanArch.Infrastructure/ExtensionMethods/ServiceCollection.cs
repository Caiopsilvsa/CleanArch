using CleanArch.Application.Repositories;
using CleanArch.Infrastructure.Repository;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArch.Infrastructure.ExtensionMethods;

public static class ServiceCollection
{
    public static void RegisterServices(this IServiceCollection services)
    {
        services.AddTransient<IContactRepository, ContactRepository>();
        services.AddTransient<IUnitOfWork, UnitOfWork>();

    }
}
