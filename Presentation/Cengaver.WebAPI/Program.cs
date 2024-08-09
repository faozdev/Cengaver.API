using Cengaver.Persistence;
using Cengaver.BL;
using Cengaver.BL.Abstractions;
using Microsoft.EntityFrameworkCore;
using Cengaver.Services.Mappings;
using AutoMapper;
using Cengaver.Infrastructure.Extentions;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddAutoMapper(typeof(MappingProfile).Assembly);

builder.Services.AddControllers();

builder.Services.AddDbContext<DataContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IUserTransactionLogService, UserTransactionLogService>();
builder.Services.AddScoped<ITeamService, TeamService>();
builder.Services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
builder.Services.AddScoped<IGuardDutyService, GuardDutyService>();
builder.Services.AddScoped<IGuardDutyNoteService, GuardDutyNoteService>();
builder.Services.AddScoped<IGuardDutyNoteTypeService, GuardDutyNoteTypeService>();
builder.Services.AddScoped<IGuardDutyBreakService, GuardDutyBreakService>();
builder.Services.AddScoped<IGuardDutyBreakTypeService, GuardDutyBreakTypeService>();
builder.Services.AddScoped<IUserCommunicationService, UserCommunicationService>();
builder.Services.AddScoped<ITeamTransactionLogService, TeamTransactionLogService>();
builder.Services.AddScoped<IPermissionService, PermissionService>();
builder.Services.AddScoped<IRoleService, RoleService>();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
