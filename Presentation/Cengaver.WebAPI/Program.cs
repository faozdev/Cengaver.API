using Cengaver.Persistence;
using Cengaver.BL;
using Cengaver.BL.Abstractions;
using Microsoft.EntityFrameworkCore;
using Cengaver.Services.Mappings;
using AutoMapper;
using Cengaver.Infrastructure.Extentions;
using Microsoft.AspNetCore.Identity;
using Cengaver.Domain;
using Microsoft.AspNetCore.Authentication.Cookies;
using System.Security.Claims;
using Microsoft.OpenApi.Models;
using Cengaver.Infrastructure.Repository;
using Microsoft.IdentityModel.Tokens;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddAutoMapper(typeof(MappingProfile).Assembly);

builder.Services.AddControllers();
builder.Services.AddAuthorization();
//builder.Services.AddAuthentication().AddCookie();

//builder.Services.AddAuthentication().AddCookie(IdentityConstants.ApplicationScheme)
//    .AddBearerToken(IdentityConstants.BearerScheme);


builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = IdentityConstants.ApplicationScheme;
    options.DefaultChallengeScheme = IdentityConstants.ApplicationScheme;
})
.AddCookie(IdentityConstants.ApplicationScheme)
.AddBearerToken(IdentityConstants.BearerScheme);

builder.Services.AddIdentityCore<User>()
    .AddEntityFrameworkStores<DataContext>()
    .AddApiEndpoints();


/*
builder.Services.AddDbContext<DataContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
*/

builder.Services.AddDbContext<DataContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
/*
builder.Services.AddIdentity<User, IdentityRole>()
    .AddEntityFrameworkStores<DataContext>()
    .AddDefaultTokenProviders();
*/

builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IUserTransactionLogService, UserTransactionLogService>();
builder.Services.AddScoped<ITeamService, TeamService>();
builder.Services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
builder.Services.AddScoped<IGuardDutyService, GuardDutyService>();
builder.Services.AddScoped<IGuardDutyNoteService, GuardDutyNoteService>();
builder.Services.AddScoped<IGuardDutyNoteTypeService, GuardDutyNoteTypeService>();
builder.Services.AddScoped<IGuardDutyBreakService, GuardDutyBreakService>();
builder.Services.AddScoped<IGuardDutyBreakTypeService, GuardDutyBreakTypeService>();
builder.Services.AddScoped<IUserCommunicationRepository, UserCommunicationRepository>();
builder.Services.AddScoped<IUserCommunicationService, UserCommunicationService>();
builder.Services.AddScoped<ITeamTransactionLogService, TeamTransactionLogService>();
builder.Services.AddScoped<IPermissionService, PermissionService>();
builder.Services.AddScoped<IRoleService, RoleService>();
builder.Services.AddScoped<IUserRoleService, UserRoleService>();
builder.Services.AddScoped<IUserTeamService, UserTeamService>();

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowSpecificOrigin",
        builder =>
        {
            builder.WithOrigins("http://localhost:5173")
                   .AllowAnyHeader()
                   .AllowAnyMethod();
        });
});

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "Auth Demo",
        Version = "v1"
    });

    options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        In = ParameterLocation.Header,
        Description = "Please enter a token",
        Name = "Authorization",
        Type = SecuritySchemeType.Http,
        BearerFormat = "JWT",
        Scheme = "bearer"
    });

    options.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,
                    Id = "Bearer"
                }
            },
            Array.Empty<string>()
        }
    });
});

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseCors("AllowSpecificOrigin");
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();
app.MapIdentityApi<User>();

app.MapGet("users/me", async (HttpContext httpContext, DataContext context) =>
{
    var userId = httpContext.User.FindFirstValue(ClaimTypes.NameIdentifier);
    if (string.IsNullOrEmpty(userId))
    {
        return Results.BadRequest("User ID not found in claims");
    }

    var user = await context.Users.FindAsync(userId);
    if (user == null)
    {
        return Results.NotFound("User not found");
    }

    return Results.Ok(user);
});

app.Run();
