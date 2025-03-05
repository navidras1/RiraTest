using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess;

namespace Service
{
    public static class Config
    {
        public static void ConfigRiraService(this IServiceCollection services, IConfiguration config)
        {
            services.ConfigRiraDataAccess(config);
            services.AddScoped(typeof(IPersonCrudService), typeof(PersonCrudService));
            services.AddScoped(typeof(IValidation), typeof(Validation));

        }
    }
}
