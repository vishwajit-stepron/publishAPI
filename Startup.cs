using Microsoft.EntityFrameworkCore;
using StepHR365.DAL.FileUpload;
using StepronEOP.DAL.UsersDAL;
using StepronEOP.Database;
using StepronEOP.Services.UsersServices;

namespace StepronEOP
{
    public class Startup
    {
        public IConfiguration Configuration { get; }

        public Startup(IConfiguration Configuration)
        {
            this.Configuration = Configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen();

            string connectionString = Configuration.GetConnectionString("SQLServer");

            services.AddDbContextPool<AppDbContext>(options =>
            {
                options.UseSqlServer(connectionString,
                               sqlServerOptionsAction: sqlOptions =>
                               {
                                   sqlOptions.EnableRetryOnFailure(
                                   maxRetryCount: 10,
                                   maxRetryDelay: TimeSpan.FromSeconds(30),
                                   errorNumbersToAdd: null
                                   );
                               });
            });

            services.AddCors(options =>
            {
                options.AddDefaultPolicy(builder =>
                {
                    builder.WithOrigins("http://localhost:3000", "http://localhost:3001")
                           .AllowAnyMethod()
                           .AllowAnyHeader();
                });
            });

            //services.AddDbContextPool<AppDbContext>(options=>options.UseNpgsql(Configuration.GetConnectionString("Postgrel")));
            //services.AddDbContextPool<AppDbContext>(options=>options.UseMySQL(Configuration.GetConnectionString("MySQL")));

            services.AddDistributedMemoryCache();

            services.AddTransient<IUserRepository, UserRepository>();
            services.AddTransient<IUserService, UserService>();

            services.AddScoped<IFileuploadService, FileUploadServices>();

            services.Configure<IISServerOptions>(options =>
            {
                options.AllowSynchronousIO = true;
            });

        }
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseStaticFiles();

            app.UseCors();

            app.UseHttpsRedirection();
            app.UseRouting();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
            app.UseSwagger();
            app.UseSwaggerUI(endpoints =>
            {
                endpoints.SwaggerEndpoint("/swagger/v1/swagger.json", "StepronPayroll");
            });
        }
    }
}
