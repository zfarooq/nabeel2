using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Client.WebAPI.Entities;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Microsoft.EntityFrameworkCore;
using AutoMapper;
using Client.WebAPI.Mappings;
using Client.WebAPI.Helper;
using System.Text;
using Client.WebAPI.Repositories;
using Client.WebAPI.Services;
using Microsoft.OpenApi.Models;
namespace Client.WebAPI
{
	public class Startup
	{
		public Startup(IConfiguration configuration)
		{
			Configuration = configuration;
		}

		public IConfiguration Configuration { get; }

		// This method gets called by the runtime. Use this method to add services to the container.
		public void ConfigureServices(IServiceCollection services)
		{
			services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
			ConfigureCors(services);
			ConfigureContext(services);
			services.AddIdentity<IdentityUser, IdentityRole>(options =>
			{
				options.User.RequireUniqueEmail = true;
			})
			.AddEntityFrameworkStores<IdentityContext>();
			services.AddDbContext<IdentityContext>(cfg =>
			{
				cfg.UseSqlServer(Configuration.GetConnectionString("IdentityContext"));
			});
			services.AddScoped<DbContext, ClientDBContext>();
			ConfigureMapper(services);
			ConfigureContainer(services);
			ConfigureAuthentication(services);
		}

		// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
		public void Configure(IApplicationBuilder app, IHostingEnvironment env)
		{
			if (env.IsDevelopment())
			{
				app.UseDeveloperExceptionPage();
			}
			app.UseCors("AllowAllOrigins");
			app.UseAuthentication();
			
			app.UseMvc();
		}
		private void ConfigureCors(IServiceCollection services)
		{
			services.AddCors(options =>
			{
				options.AddPolicy("AllowAllOrigins",
					builder =>
					{
						builder.AllowAnyMethod()
						.AllowAnyHeader()
						.AllowAnyOrigin();
					});
			});
		}
		private void ConfigureContext(IServiceCollection services)
		{
			services.AddDbContext<ClientDBContext>
				(options =>
					options.UseSqlServer(Configuration.GetConnectionString("DataContext"))
				);
		}
		private void ConfigureMapper(IServiceCollection services)
		{
			var mappingConfig = new MapperConfiguration(mc =>
			{
				mc.AddProfile(new ClientMap());
				mc.AddProfile(new UserMap());
				mc.AddProfile(new RoleMap());

			});
			IMapper mapper = mappingConfig.CreateMapper();
			services.AddSingleton(mapper);
		}
		private void ConfigureAuthentication(IServiceCollection services)
		{
			var appSettingsSection = Configuration.GetSection("AppSettings");
			services.Configure<AppSettings>(appSettingsSection);

			var appSettings = appSettingsSection.Get<AppSettings>();
			var key = Encoding.ASCII.GetBytes(appSettings.Secret);
			services.AddAuthentication(x =>
			{
				x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
				x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
			})
		   .AddJwtBearer(x =>
		   {
			   x.RequireHttpsMetadata = false;
			   x.SaveToken = true;
			   x.TokenValidationParameters = new TokenValidationParameters
			   {
				   ValidateIssuerSigningKey = true,
				   IssuerSigningKey = new SymmetricSecurityKey(key),
				   ValidateIssuer = false,
				   ValidateAudience = false
			   };
		   });
		}
		private void ConfigureContainer(IServiceCollection services)
		{
			services.AddScoped<IUserService, UserService>();
			services.AddScoped<IUserRepository, UserRepository>();
		}
	}
}
