using HR.LeaveManagement.API.Filters.CustomAttributes;
using HR.LeaveManagement.API.Interface;
using HR.LeaveManagement.API.Middlewares;
using HR.LeaveManagement.API.Policy;
using HR.LeaveManagement.API.Policy.Handler;
using HR.LeaveManagement.API.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddTransient<IApiKeyValidation, ApiKeyValidation>();
//need for custom attribute
builder.Services.AddScoped<ApiKeyAuthFilter>();
//needed to register the IHttpContextAccessor to have access to HttpContext
builder.Services.AddHttpContextAccessor();
//authentication with jwt
builder.Services.AddAuthentication(opt =>
{
    opt.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer();//for policy based validation

//authorization with jwt
builder.Services.AddAuthorization(opt =>
{
    opt.AddPolicy("ApiKeyPolicy", policy =>
    {
        policy.AddAuthenticationSchemes(new[] { JwtBearerDefaults.AuthenticationScheme });
        policy.Requirements.Add(new ApiKeyRequirement());
    });
});//for policy based validation

builder.Services.AddScoped<IAuthorizationHandler, ApiKeyHandler>();//for policy based validation

builder.Services.AddControllers();
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
//note once this middle is enabled it runs before even the attributes or filters are reached
//app.UseMiddleware<ApiKeyMiddleware>();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
