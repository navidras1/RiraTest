using DataAccess.Context;
using DataAccess.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    static public class Config
    {
        public static void ConfigRiraDataAccess(this IServiceCollection services, IConfiguration config) {

            var RiraConnectioString =  config["ConnectionStrings:Rira"];
            services.AddDbContext<RiraContext>(options => {
                options.UseSqlite(RiraConnectioString);
            });

            services.AddScoped(typeof(IRiraRepository<>), typeof(RiraRepository<>));
        
        }
    }
}
