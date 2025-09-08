using BE_QLSV.Data;
using BE_QLSV.Interfaces;
using BE_QLSV.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

builder.Services.AddDbContext<StudentManagerDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("SchoolDb")));

builder.Services.AddCors(options => { options.AddPolicy("AllowFrontEnd", policy => policy.WithOrigins("http://localhost:5173").AllowAnyHeader().AllowAnyMethod()); });


builder.Services.AddScoped<IRoleServices, RoleServices>();
builder.Services.AddScoped<IClassServices, ClassServices>();
builder.Services.AddScoped<ISubjectServices, SubjectServices>();
builder.Services.AddScoped<IStudentServices, StudentServices>();
builder.Services.AddScoped<ILecturerServices, LecturerServices>();
builder.Services.AddScoped<IAccountService, AccountService>();



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

app.UseCors("AllowFrontEnd");

app.UseAuthorization();

app.MapControllers();

app.Run();
