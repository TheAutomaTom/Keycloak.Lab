using System.Data;
using Keycloak.AuthServices.Authentication;
using Keycloak.AuthServices.Authorization;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.OpenApi.Models;

namespace Keycloak.Lab
{
  public class Program
  {
    public static void Main(string[] args)
    {

      var env = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");
      if (env == null)
      {
        // Set the default environment to Development
        Environment.SetEnvironmentVariable("ASPNETCORE_ENVIRONMENT", "Test");
        env ??= Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");
      }

      var configuration = new ConfigurationBuilder()
        .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
        .AddJsonFile($"appsettings.{env}.json", optional: true
        ).Build();


      var builder = WebApplication.CreateBuilder(args);


      // Add services to the container.
      builder.Services.AddKeycloakWebApiAuthentication(configuration, o =>
      {

        if (env == "Development" || env == "Test")
        {
          o.RequireHttpsMetadata = false; // Disable typical Https requirement.
        }
        //options.Audience = configuration.GetSection("Keycloak:audience").Value; // Is an audience required?
      });


      builder.Services.AddAuthorization(options =>
      {

        options.AddPolicy("Reader", p => { p.RequireResourceRoles("Reader"); });
        options.AddPolicy("Writer", p => { p.RequireResourceRoles("Writer"); });
        options.AddPolicy("Admin", p => { p.RequireResourceRoles("Admin"); });

        
        options.AddPolicy("AdminOrWriters", p => { p.RequireResourceRoles("Admin" /* OR REQUIRE */, "Writer"); }); 


        options.AddPolicy("ReadAndWriters", p => { 
          p.RequireResourceRoles("Reader" );
          /* AND REQUIRE */
          p.RequireResourceRoles("Writer"); 
        });

      })
      .AddKeycloakAuthorization(configuration);

      builder.Services.AddControllers();
      // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
      builder.Services.AddEndpointsApiExplorer();


      builder.Services.AddSwaggerGen(option =>
      {
        option.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
        {
          In = ParameterLocation.Header,
          Description = "Please enter a valid token",
          Name = "Authorization",
          Type = SecuritySchemeType.Http,
          BearerFormat = "JWT",
          Scheme = "Bearer"
        });
        option.AddSecurityRequirement(new OpenApiSecurityRequirement
        {
            {
              new OpenApiSecurityScheme
              {
                Reference = new OpenApiReference
                {
                  Type=ReferenceType.SecurityScheme,
                  Id="Bearer"
                }
              },
              new string[]{}
            }
        });
      });

      var app = builder.Build();

      app.UseAuthentication();
      app.UseAuthorization();

      // Configure the HTTP request pipeline.
      if (app.Environment.IsDevelopment())
      {
        app.UseSwagger();
        app.UseSwaggerUI(options => options.EnableTryItOutByDefault());
      }

      app.UseHttpsRedirection();

      app.MapControllers();

      app.Run();
    }
  }
}
