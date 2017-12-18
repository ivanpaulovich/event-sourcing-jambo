namespace Jambo.Producer.UI
{
    using Autofac;
    using Autofac.Configuration;
    using Jambo.Producer.UI.Filters;
    using Microsoft.AspNetCore.Authentication.JwtBearer;
    using Microsoft.AspNetCore.Builder;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.IdentityModel.Tokens;
    using Swashbuckle.AspNetCore.Swagger;
    using System;
    using System.IO;
    using System.Linq;
    using System.Runtime.Loader;
    using System.Text;

    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        
        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc(options =>
            {
                options.Filters.Add(typeof(DomainExceptionFilter));
                options.Filters.Add(typeof(ValidateModelAttribute));
                options.Filters.Add(typeof(CorrelationFilter));
            });

            services.AddSwaggerGen(options =>
            {
                options.AddSecurityDefinition(
                    "Bearer",
                    new ApiKeyScheme()
                    {
                        In = "header",
                        Description = "Please insert JWT with Bearer into field",
                        Name = "Authorization",
                        Type = "apiKey"
                    });

                options.DescribeAllEnumsAsStrings();

                options.SwaggerDoc("v1", new Swashbuckle.AspNetCore.Swagger.Info
                {
                    Title = "Blogging HTTP API",
                    Version = "v1",
                    Description = "The Blogging Service HTTP API",
                    TermsOfService = "Terms Of Service"
                });
            });

            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options =>
                {
                    options.SaveToken = true;
                    options.RequireHttpsMetadata = false;
                    options.TokenValidationParameters = new TokenValidationParameters()
                    {
                        ValidIssuer = Configuration.GetSection("Security").GetValue<string>("Issuer"),
                        ValidAudience = Configuration.GetSection("Security").GetValue<string>("Issuer"),
                        IssuerSigningKey = new SymmetricSecurityKey(
                            Encoding.UTF8.GetBytes(
                                Configuration.GetSection("Security").GetValue<string>("SecretKey")))
                    };
                });
        }

        public void ConfigureContainer(ContainerBuilder builder)
        {
            LoadInfrastructureAssemblies();
            builder.RegisterModule(new ConfigurationModule(Configuration));
        }

        private void LoadInfrastructureAssemblies()
        {
            string[] fileNames = Directory.EnumerateFiles(AppDomain.CurrentDomain.BaseDirectory, "*.dll", SearchOption.TopDirectoryOnly)
                .Where(filePath => Path.GetFileName(filePath).StartsWith("Jambo.Producer.Infrastructure", StringComparison.OrdinalIgnoreCase))
                .ToArray();

            foreach (string file in fileNames)
                AssemblyLoadContext.Default.LoadFromAssemblyPath(file);
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseAuthentication();

            app.UseMvc();

            app.UseSwagger()
               .UseSwaggerUI(c =>
               {
                   c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
               });
        }
    }
}
