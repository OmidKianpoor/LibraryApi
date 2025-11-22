using LibraryApi;
using LibraryApi.DbContexts;
using LibraryApi.Repositories;
using LibraryApi.Services.AuthenticationService;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers
     (option => option.ReturnHttpNotAcceptable = true).AddNewtonsoftJson()
    .AddXmlDataContractSerializerFormatters();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen(opt =>
{
    opt.SwaggerDoc("v1", new OpenApiInfo { Title = "libraryapi", Version = "v1" });

    // Define the Bearer authentication scheme
    opt.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        In = ParameterLocation.Header,
        Description = "Enter JWT token with Bearer prefix (Example: 'Bearer {token}')",
        Name = "Authorization",
        Type = SecuritySchemeType.Http,
        BearerFormat = "JWT",
        Scheme = "bearer"
    });

    // Require Bearer token for all endpoints by default
    opt.AddSecurityRequirement(new OpenApiSecurityRequirement
{
{
new OpenApiSecurityScheme
{
Reference = new OpenApiReference
{
Type = ReferenceType.SecurityScheme,
Id = "Bearer"
},
// The following fields help Swagger UI wire up the header correctly
Scheme = "bearer",
Name = "Authorization",
In = ParameterLocation.Header
},
new string[] { }
}
});

});


builder.Services.AddAutoMapper(typeof(Program).Assembly);




builder.Services.AddDbContext<LibraryDbContext>(options =>
{ options.UseSqlServer(builder.Configuration["ConnectionStrings:LibraryConnection"]); });

builder.Services.AddScoped<ILibraryRepository,LibraryRepository>();
builder.Services.AddScoped<IAuthenticationServices, AuthenticationServices>();

builder.Services.AddAuthentication(opt =>
{
    opt.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    opt.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
})
.AddJwtBearer(options =>
{
    options.RequireHttpsMetadata = true;
    options.SaveToken = true;
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuerSigningKey = true,
        IssuerSigningKey = new SymmetricSecurityKey(
    Encoding.ASCII.GetBytes(builder.Configuration["Authentication:SecretForKey"])),
        ValidateIssuer = true,
        ValidIssuer = builder.Configuration["Authentication:Issuer"],
        ValidateAudience = true,
        ValidAudience = builder.Configuration["Authentication:Audience"]
    };
});


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseRouting();

app.UseAuthentication();

app.UseAuthorization();



app.MapControllers();



app.Run();
