using AutoMapper;
using Core.Mapper;
using Core.Services;
using Data.Context;
using Data.Repository;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace WebApplication2;

public static class CompositionRoot
{
    public static void AddDependencies(this IServiceCollection services, IConfiguration configuration)
    {
        //All services will register here
        services.AddScoped<IStandardService, StandardService>();
        services.AddScoped<IStandardRepository, StandardRepository>();
        services.AddScoped<IStudentService, StudentService>();
        services.AddScoped<IStudentRepository, StudentRepository>();
        services.AddScoped<ITeacherService, TeacherService>();
        services.AddScoped<ITeacherRepository, TeacherRepository>();
        services.AddScoped<ISubjectRepository, SubjectRepository>();
        services.AddScoped<ISubjectService,SubjectService>();
        services.AddScoped<ILanguageRepository,LanguageRepository>();
        services.AddScoped<ILanguageService,LanguageService>();
        services.AddScoped<ITeacherSubjectRepository, TeacherSubjectRepository>();
        /*Auto mapper*/
        services.AddAutoMapper(typeof(MappingProfile));

        /*Enable CORS*/
        services.AddCors(options => options.AddPolicy(name: "MyPolicy", builder =>
        {
            builder.WithOrigins("http://localhost:4200").AllowAnyMethod().AllowAnyHeader();
            builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader();
        }));
    }
    public static void AddDbContext(this IServiceCollection services, IConfiguration configuration)
    {
        var connectionString = configuration.GetConnectionString("DefaultConnection");
        services.AddDbContext<ApplicationDbContext>(options =>
            options.UseSqlServer(connectionString, sqlOptions =>
            {
                sqlOptions.EnableRetryOnFailure(
                    3,
                    TimeSpan.FromSeconds(10),
                    null);
            }), ServiceLifetime.Transient, ServiceLifetime.Transient);
    }
}
