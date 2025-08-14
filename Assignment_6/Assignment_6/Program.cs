using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Assignment_6.Data;
using Assignment_6.Repositories;
using Assignment_6.Repositories.Implementations;
using Assignment_6.Services;
using Microsoft.OpenApi.Models;
namespace Assignment_6
{
    public class Program
    {
        public static void Main(string[] args)
        {

            // *************UNCOMMENT THIS TO USE IN SWAGGER*****************
            // *********ALSO CHANGE THE launch url to swagger when doing so*********
            // ************LET THE OTHER IMPLEMENTATION STAY COMMENTED IF THIS IS UNCOMMENTED***********

            /*var builder = WebApplication.CreateBuilder(args);

            // configuration
            builder.Services.AddControllers();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            // config objects
            builder.Services.Configure<DbSettings>(builder.Configuration.GetSection("ConnectionStrings"));

            // DI: Repositories
            builder.Services.AddScoped<IVisitRepository, VisitRepository>();
            builder.Services.AddScoped<IPatientRepository, PatientRepository>();
            builder.Services.AddScoped<IDoctorRepository, DoctorRepository>();
            builder.Services.AddScoped<IUserRepository, UserRepository>();

            // Services
            builder.Services.AddScoped<IAuthService, AuthService>();

            // JWT
            var jwtSection = builder.Configuration.GetSection("Jwt");
            var key = Encoding.UTF8.GetBytes(jwtSection["Key"]);

            builder.Services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(options =>
            {
                options.RequireHttpsMetadata = false;
                options.SaveToken = true;
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidIssuer = jwtSection["Issuer"],
                    ValidateAudience = true,
                    ValidAudience = jwtSection["Audience"],
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateLifetime = true
                };
            });

            //builder.Services.AddAuthorization();

            var app = builder.Build();

            app.UseSwagger();
            app.UseSwaggerUI();

            app.UseStaticFiles();
            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.MapControllers();

            app.Run();*/

            // *************UNCOMMENT THIS TO USE IN SWAGGER *****************
            // *********ALSO CHANGE THE launch url to swagger when doing so*********
            // ************LET THE OTHER IMPLEMENTATION STAY COMMENTED IF THIS IS UNCOMMENTED***********


           /* \
            \
            \
            \
            \
            \
            \
            \
            \
            \
            \
            \
            \*/


            // *************UNCOMMENT THIS TO USE IN html*****************
            // *********ALSO CHANGE THE launch url to index.html when doing so*********
            // ************LET THE OTHER IMPLEMENTATION STAY COMMENTED IF THIS IS UNCOMMENTED***********
            var builder = WebApplication.CreateBuilder(args);
            builder.Services.Configure<DbSettings>(builder.Configuration.GetSection("ConnectionStrings"));

            // DI: Repositories
            builder.Services.AddScoped<IVisitRepository, VisitRepository>();
            builder.Services.AddScoped<IPatientRepository, PatientRepository>();
            builder.Services.AddScoped<IDoctorRepository, DoctorRepository>();
            builder.Services.AddScoped<IUserRepository, UserRepository>();

            // Services
            builder.Services.AddScoped<IAuthService, AuthService>();
            // Add services
            builder.Services.AddControllers();

            var app = builder.Build();

            // Serve index.html from wwwroot when user opens the app
            app.UseDefaultFiles();   // Looks for index.html by default
            app.UseStaticFiles();    // Serves files from wwwroot

            // Map API controllers
            app.MapControllers();

            app.Run();


            // *************UNCOMMENT THIS TO USE IN html*****************
            // *********ALSO CHANGE THE launch url to index.html when doing so*********
            // ************LET THE OTHER IMPLEMENTATION STAY COMMENTED IF THIS IS UNCOMMENTED***********

        }
    }
}
