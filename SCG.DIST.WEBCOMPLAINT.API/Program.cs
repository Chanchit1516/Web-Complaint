using Autofac;
using Autofac.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using SCG.DIST.WEBCOMPLAINT.INFRASTRUCTURE.Data;
using Swashbuckle.AspNetCore.SwaggerUI;
using System.Text;
using static CleanArch.Api.DependencyConfig;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
string buildVersion = Environment.GetEnvironmentVariable("BUILD_VERSION");

builder.Services.AddControllers();
builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory());
builder.Services.AddSingleton<Microsoft.AspNetCore.Http.IHttpContextAccessor, Microsoft.AspNetCore.Http.HttpContextAccessor>();
builder.Services.AddHttpContextAccessor();

//DB Postgrest
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultDatabase")));

#region "HSTS"
builder.Services.AddHsts(options =>
{
    options.Preload = true;
    options.IncludeSubDomains = true;
    options.MaxAge = TimeSpan.FromDays(60);
    options.ExcludedHosts.Add("https://veapp.nexterdigitals-dev.com/");
});
#endregion


#region Authentication

builder.Services
       .AddAuthentication(options =>
       {
           options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
           options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
           options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;

       })
       .AddJwtBearer(cfg =>
       {
           cfg.RequireHttpsMetadata = false;
           cfg.SaveToken = true;
           cfg.TokenValidationParameters = new TokenValidationParameters
           {
               ValidIssuer = builder.Configuration["AppSettings:JwtIssuer"],
               ValidAudience = builder.Configuration["AppSettings:JwtAudience"],
               IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["AppSettings:JwtKey"])),
               ClockSkew = TimeSpan.Zero // remove delay of token when expire
           };
       });


#endregion Authentication

builder.Services.AddCors(o => o.AddPolicy("MyPolicy", builder =>
{
    builder.AllowAnyOrigin()
           .AllowAnyMethod()
           .AllowAnyHeader();
}));


builder.Services.AddEndpointsApiExplorer();
#region config swagger
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "API-CORE :" + buildVersion,
        Version = "v1",
        Description = "Full documentation to ASPNETCore public API",
        Contact = new OpenApiContact
        {
            Name = "Zoccarato Davide",
            Email = "davide@davidezoccarato.cloud",
            Url = new Uri("https://www.davidezoccarato.cloud/")
        },
    });

    c.AddSecurityDefinition("basic", new OpenApiSecurityScheme
    {
        Name = "Authorization",
        Type = SecuritySchemeType.Http,
        Scheme = "basic",
        In = ParameterLocation.Header,
        Description = "Basic Authorization header using the Bearer scheme."
    });
    c.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                          new OpenApiSecurityScheme
                            {
                                Reference = new OpenApiReference
                                {
                                    Type = ReferenceType.SecurityScheme,
                                    Id = "basic"
                                }
                            },
                            new string[] {}
                    }
                });

    c.IgnoreObsoleteProperties();
    #endregion

    #region Register Authentication

    var securitySchema = new OpenApiSecurityScheme
    {
        Description = "JWT Authorization header \"Authorization: Bearer {token}\"",
        Name = "authorization",
        In = ParameterLocation.Header,
        Type = SecuritySchemeType.Http,
        Scheme = "bearer",
        Reference = new OpenApiReference
        {
            Type = ReferenceType.SecurityScheme,
            Id = "Bearer",
        }
    };
    c.AddSecurityDefinition("Bearer", securitySchema);
    c.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    { securitySchema, new[] { "Bearer" } },
                });
    #endregion Register Authentication

});

builder.Services.Configure<ApiBehaviorOptions>(options
    => options.SuppressModelStateInvalidFilter = true);

builder.Host.ConfigureContainer<ContainerBuilder>(builder => builder.RegisterModule(new RegisterServiceModule()));
builder.Host.ConfigureContainer<ContainerBuilder>(builder => builder.RegisterModule(new MediatorModule()));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseRouting();

app.UseCors("MyPolicy");

app.UseAuthorization();

app.MapControllers();

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();
});

#region "HSTS"
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}
#endregion

var AutofacContainer = app.Services.GetAutofacRoot();

app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("v1/swagger.json", "SCM API:" + app.Environment.EnvironmentName);
    c.DocExpansion(DocExpansion.None);
    c.OAuthClientId("");
    c.OAuthClientSecret("");
});

if (string.IsNullOrWhiteSpace(app.Environment.WebRootPath))
{
    app.Environment.WebRootPath = Path.Combine(Directory.GetCurrentDirectory(), "");
}

app.Run();