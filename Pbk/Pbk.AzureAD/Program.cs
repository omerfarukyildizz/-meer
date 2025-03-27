using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.OpenApi.Models;
using Edp.DataAccess;
using Edp.WebApi.AzureAD.Middleware;
using Edp.Core.Features.User;
using Edp.DataAccess.Mapping;
using Microsoft.Identity.Web;
 
using Edp.Core.Features.Users.Manager;
using Edp.Entities.Options;
using Edp.Core.Features.Users;
using Edp.Core;

var builder = WebApplication.CreateBuilder(args);


builder.Services
    .AddMicrosoftIdentityWebApiAuthentication(builder.Configuration);
builder.Services.Configure<Jwt>(builder.Configuration.GetSection("Jwt"));

builder.Services.AddAuthorization();
builder.Services.AddAuthorization();
builder.Services.AddBusinessCore();
 

builder.Services.AddDataAccess(builder.Configuration);
builder.Services.AddTransient<ExceptionMiddleware>();
builder.Services.AddTransient<ITranslate, TanslateCommandHandler>();
builder.Services.AddTransient<IUserManager, BarisUserManager>();
builder.Services.AddMemoryCache();
builder.Services.AddResponseCaching();
builder.Services.AddControllers();
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

var Origins = "_Barsis";


/*--------- Deployment �ncesi kural --UAT i�in bu kapat?lacak. sadece .barsan �zerinden gelen isteklere cevap verilecek.*/
builder.Services.AddCors(options =>
{
    options.AddPolicy(Origins,
                          policy =>
                          {
                              policy.AllowCredentials().SetIsOriginAllowed(origin => true).AllowAnyHeader().AllowAnyMethod();
                          });
});

/*---------- Deployment �ncesi kural*/

builder.Services.AddAutoMapper(typeof(MapsterSettings));

var app = builder.Build();
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors(Origins);
app.UseResponseCaching();
app.UseMiddleware<ExceptionMiddleware>();
app.UseHttpsRedirection();
app.MapControllers();
app.Run();
