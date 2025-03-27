using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Pbk.DataAccess;
using Pbk.WebApi.Middleware;
using System.Text;
using Pbk.Core.Features.User;
using Pbk.DataAccess.Mapping;
using Pbk.Core.Features.Users.Manager;
using Pbk.Core.Helpers;
using Pbk.Entities.Options;
using Pbk.Entities.Repositories;
using Pbk.Core;
using Pbk.Core.Features.Users;
using Pbk.Core.Features.EndPoints.Get;
using Microsoft.EntityFrameworkCore;
using Pbk.DataAccess.Context;

var builder = WebApplication.CreateBuilder(args);
builder.Services.Configure<Jwt>(builder.Configuration.GetSection("Jwt"));
var serviceProvider = builder.Services.BuildServiceProvider();
var jwtConfiguration = serviceProvider.GetRequiredService<IOptions<Jwt>>().Value;

builder.Services.AddAuthentication().AddJwtBearer(cfr =>
{
    cfr.TokenValidationParameters = new()
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateIssuerSigningKey = true,
        ValidateLifetime = true,
        ValidIssuer = jwtConfiguration.Issuer,
        ValidAudience = jwtConfiguration.Audience,
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtConfiguration.SecretKey))
    };
});

builder.Services.AddAuthorization();
builder.Services.AddBusinessCore();
//builder.Services.AddBusinessShipment();
//builder.Services.AddBusinessOcean();
//builder.Services.AddBusinessFAM();
builder.Services.AddDataAccess(builder.Configuration);
builder.Services.AddTransient<ExceptionMiddleware>();
builder.Services.AddTransient<ITranslate, TanslateCommandHandler>();
builder.Services.AddTransient<IUserManager, BarisUserManager>();
builder.Services.AddTransient<IAuthorityHelper, AuthorityHelper>();



builder.Services.AddMemoryCache();
builder.Services.AddResponseCaching();
builder.Services.AddControllers();
builder.Services.AddHttpContextAccessor();
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen(setup =>
{
    var jwtSecuritySheme = new OpenApiSecurityScheme
    {
        BearerFormat = "JWT",
        Name = "JWT Authentication",
        In = ParameterLocation.Header,
        Type = SecuritySchemeType.Http,
        Scheme = JwtBearerDefaults.AuthenticationScheme,
        Description = "Put **_ONLY_** yourt JWT Bearer token on textbox below!",
        Reference = new OpenApiReference
        {
            Id = JwtBearerDefaults.AuthenticationScheme,
            Type = ReferenceType.SecurityScheme
        }
    };

    setup.AddSecurityDefinition(jwtSecuritySheme.Reference.Id, jwtSecuritySheme);
    setup.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    { jwtSecuritySheme, Array.Empty<string>() }
                });
});

var origins = "_Barsis";


/*--------- Deployment �ncesi kural --UAT i�in bu kapat?lacak. sadece .barsan �zerinden gelen isteklere cevap verilecek.*/
builder.Services.AddCors(options =>
{
    options.AddPolicy(origins,
                          policy =>
                          {
                              policy.AllowCredentials()
                              .SetIsOriginAllowed(origin => true)
                                                  .AllowAnyHeader()
                                                  .AllowAnyMethod();
                          });
});

/*---------- Deployment �ncesi kural*/

builder.Services.AddAutoMapper(typeof(MapsterSettings));


//builder.Services.AddDbContext<ContextBarsan>(options =>
//    options.UseSqlServer($@"Data Source=bglsqlprod.barsan.com;
//                           Initial Catalog=Barsan{DateTime.Now.Year};
//                           User ID=BGL;Password=56547845;
//                           MultipleActiveResultSets=True;TrustServerCertificate=True;"));



var app = builder.Build();

if (app.Environment.IsDevelopment()) { }

app.UseSwagger();
app.UseSwaggerUI();

app.UseCors(origins);
app.UseResponseCaching();
app.UseMiddleware<ExceptionMiddleware>();
app.UseHttpsRedirection();
app.MapControllers();
app.Run();
