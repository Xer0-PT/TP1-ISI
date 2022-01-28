using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Formatters;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using System;
using System.Reflection;
using System.IO;
using Microsoft.EntityFrameworkCore;
using RestfullAPI.Context;
using RestfullAPI.Infrastructure.Services;
using RestfullAPI.Infrastructure.Repositories;
using Newtonsoft.Json.Converters;
using System.Text.Json.Serialization;
using TP1.Domain.Context;
using WorkerBackground;
using PersonSoapService;
using RestfullAPI.Connected_Services.PersonSoapService;
using Microsoft.AspNetCore.Authentication.JwtBearer;

namespace RestfullAPI
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

            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(options =>
            {
                options.Authority = $"https://{Configuration["Auth0:Domain"]}/";
                options.Audience = Configuration["Auth0:Audience"];
            });

            //SERVICES
            services.AddTransient<IDashboardService, DashboardService>();
            services.AddTransient<IProductService, ProductService>();
            services.AddTransient<IRequisitionService, RequisitionService>();
            services.AddTransient<ITeamService, TeamService>();
            services.AddTransient<IPersonService, PersonService>();

            // Serviço SOAP
            services.AddTransient<IPersons, PersonsClient>();

            //REPOS
            services.AddTransient<IProductRepository, ProductRepository>();
            services.AddTransient<IRequisitionRepository, RequisitionRepository>();
            services.AddTransient<ITeamRepository, TeamRepository>();
            services.AddTransient<IDashboardRepository, DashboardRepository>();
            services.AddTransient<IPersonRepository, PersonRepository>();

            services.AddCors();

            services.AddControllers(configure =>
            {
                configure.OutputFormatters.RemoveType<StringOutputFormatter>();
            })
                .AddNewtonsoftJson(options =>
                {
                    options.SerializerSettings.Converters.Add(new StringEnumConverter());
                    options.SerializerSettings.NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore;
                    options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;
                })

                .AddJsonOptions(options =>
                options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter()));

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "RESTfull API",
                    Version = "v1",
                    Description = "RESTfull API no ambito da unidade curricular de ISI"
                });
                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                //c.IncludeXmlComments(xmlPath);
                c.EnableAnnotations();

                var securitySchema = new OpenApiSecurityScheme
                {
                    Description = "Authorization header with the Bearer scheme.",
                    Name = "Authorization",
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.Http,
                    Scheme = "bearer",
                    Reference = new OpenApiReference
                    {
                        Type = ReferenceType.SecurityScheme,
                        Id = "Bearer"
                    }
                };

                c.AddSecurityDefinition("Bearer", securitySchema);

                c.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                        { securitySchema, new[] { "Bearer" } }
                });



            });

            services.AddDbContext<DataContext>();



            services.AddHostedService<Worker>();

            services.AddLogging();


            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());



        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "RestfullAPI v1"));
            }

            app.UseHttpsRedirection();



            app.UseRouting();

            // global cors policy
            app.UseCors(x => x
                .AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader());

            app.UseAuthentication();
            app.UseAuthorization();



            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
