using AutoMapper;
using Hangfire;
using Hangfire.SqlServer;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using StrategyGame.Api.Mappers;
using StrategyGame.Bll.Hubs;
using StrategyGame.Bll.Mappers;
using StrategyGame.Bll.ServiceInterfaces;
using StrategyGame.Bll.ServiceInterfaces.AAAServiceInterfaces;
using StrategyGame.Bll.Services;
using StrategyGame.Bll.Services.AAAServices;
using StrategyGame.Dal.Context;
using StrategyGame.Model.Entities.Identity;
using Swashbuckle.AspNetCore.Swagger;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Text;

namespace StrategyGame.Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        private readonly string MyAllowSpecificOrigins = "_myAllowSpecificOrigins";

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {


            services.AddHangfire(configuration => configuration
       .SetDataCompatibilityLevel(CompatibilityLevel.Version_170)
       .UseSimpleAssemblyNameTypeSerializer()
       .UseRecommendedSerializerSettings()
       .UseSqlServerStorage(Configuration.GetConnectionString("StrategyGameContextConnection"), new SqlServerStorageOptions
       {
           CommandBatchMaxTimeout = TimeSpan.FromMinutes(5),
           SlidingInvisibilityTimeout = TimeSpan.FromMinutes(5),
           QueuePollInterval = TimeSpan.Zero,
           UseRecommendedIsolationLevel = true,
           UsePageLocksOnDequeue = true,
           DisableGlobalLocks = true
       }));

            services.Configure<IdentityOptions>(options =>
            {
                // Password settings.
                options.Password.RequireDigit = true;
                options.Password.RequireLowercase = true;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireUppercase = true;
                options.Password.RequiredLength = 6;
                options.Password.RequiredUniqueChars = 0;

                // User settings.
                options.User.AllowedUserNameCharacters =
                "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789-._@";
                options.User.RequireUniqueEmail = true;
            });

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);

            services.AddDbContext<StrategyGameContext>(options =>
                options.UseSqlServer(
                    Configuration.GetConnectionString("StrategyGameContextConnection")));

            services.AddIdentity<StrategyGameUser, StrategyGameRole>(options =>
            {
                options.Password.RequireDigit = false;
                options.Password.RequiredLength = 0;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireUppercase = false;
            })
                .AddEntityFrameworkStores<StrategyGameContext>()
                .AddDefaultTokenProviders();

            JwtSecurityTokenHandler.DefaultInboundClaimTypeMap.Clear();
            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(cfg =>
            {
                cfg.RequireHttpsMetadata = false;
                cfg.SaveToken = true;
                cfg.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidIssuer = Configuration["JwtIssuer"],
                    ValidAudience = Configuration["JwtIssuer"],
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["JwtKey"])),
                    ClockSkew = TimeSpan.Zero
                };
            });
            services.AddScoped<IOrszagService, OrszagService>();
            services.AddScoped<IGlobalService, GlobalService>();
            services.AddScoped<IEpuletService, EpuletService>();
            services.AddScoped<ICommonService, CommonService>();
            services.AddScoped<IEgysegService, EgysegService>();
            services.AddScoped<IFejlesztesService, FejlesztesService>();
            services.AddScoped<ITamadasService, TamadasService>();
            services.AddScoped<IJWTService, JWTService>();
            services.AddScoped<ILoginService, LoginService>();
            services.AddScoped<IRegistrationService, RegistrationService>();
            services.AddScoped<IEndTurnService, EndTurnService>();
            services.AddHangfireServer();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v0.1", new Info { Title = "UnderSeaApi", Version = "v0.1" });
            });

            services.AddCors();
            /*services.AddCors(options =>
            {
                options.AddPolicy(MyAllowSpecificOrigins,
                builder =>
                {
                    builder.WithOrigins("localhost:4200").AllowAnyMethod().AllowAnyOrigin().AllowAnyHeader();
                });
            });*/
            services.AddRouting(opt => opt.LowercaseUrls = true);
            services.AddMvc();
            var mappingConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new FejlesztesProfile());
                mc.AddProfile(new AllapotProfile());
                mc.AddProfile(new CsapatProfile());
                mc.AddProfile(new EgysegProfile());
                mc.AddProfile(new EpuletProfile());
                mc.AddProfile(new JatekProfile());
                mc.AddProfile(new OrszagProfile());
                mc.AddProfile(new UserProfile());
                mc.AddProfile(new ViewModelProfile());
            });
            IMapper mapper = mappingConfig.CreateMapper();
            services.AddSingleton(mapper);
            services.AddSignalR();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, IBackgroundJobClient backgroundJobs, StrategyGameContext ctx, IEndTurnService endTurnService)
        {


            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseCors(builder =>
            {
                builder.WithOrigins("http://localhost:4200")
                .AllowAnyHeader().AllowAnyMethod().AllowCredentials();
            });
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("./swagger/v0.1/swagger.json", "UnderSea API v0.1");
                c.RoutePrefix = string.Empty;
            });

            app.UseSignalR(routes =>
            {
                routes.MapHub<NextTurnHub>("/notify");
            });

            JobStorage.Current = new SqlServerStorage(Configuration.GetConnectionString("StrategyGameContextConnection"));

            RecurringJob.AddOrUpdate(
                    () => endTurnService.NextTurn(),
                    Cron.Minutely);

            app.UseAuthentication();
            app.UseMvc();


            //ctx.Database.EnsureCreated();
        }
    }
}
