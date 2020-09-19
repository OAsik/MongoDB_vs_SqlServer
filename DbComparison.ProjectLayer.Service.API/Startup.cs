using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using DbComparison.ProjectLayer.Repository;
using Microsoft.Extensions.DependencyInjection;
using DbComparison.ProjectLayer.Repository.Base;
using DbComparison.DataLayer.MongoDB.Setting.Base;
using DbComparison.ProjectLayer.Data.Common.Model;
using DbComparison.ProjectLayer.Business.Operation;
using DbComparison.ProjectLayer.Data.MongoDb.Setting;
using DbComparison.ProjectLayer.Business.Operation.Base;
using DbComparison.ProjectLayer.Data.SqlServer.DataContext;

namespace DbComparison.ProjectLayer.Service.API
{
    public class Startup
    {
        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<SqlServerDbContext>(opts => opts.UseSqlServer(Configuration.GetConnectionString("SqlServerConnection")));
            services.Configure<MongoDbSetting>(Configuration.GetSection("MongoDbSettings"));

            services.AddTransient<IUserRepository<User>, UserRepository>();
            services.AddTransient<IUserOperation, UserOperation>();

            services.AddSingleton<IMongoDbSetting>(serviceProvider => serviceProvider.GetRequiredService<IOptions<MongoDbSetting>>().Value);

            services.AddControllers();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}