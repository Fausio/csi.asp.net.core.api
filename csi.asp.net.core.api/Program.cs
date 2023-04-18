using csi.asp.net.core.data.Seed;
using csi.asp.net.core.service.Interface;
using csi.asp.net.core.service.service;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Identity.Web;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddMicrosoftIdentityWebApi(builder.Configuration.GetSection("AzureAd"));

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


builder.Services.AddCors(opt =>
{
    opt.AddPolicy("csi.angular.front",
        builder =>
        { 
            builder.WithOrigins("*").AllowAnyMethod().AllowAnyHeader();
        });
});


builder.Services.AddHttpContextAccessor(); 
#region IOC
builder.Services.AddSingleton<ISiteInterface, SiteService>();
builder.Services.AddSingleton<IPartnerInterface, PartnerService>();
builder.Services.AddSingleton<IHouseholdInterface, HouseholdService>();
 


#endregion

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}




await SeedData.Run();

app.UseHttpsRedirection();

app.UseAuthentication();

#region app cors  
app.UseCors("csi.angular.front");
#endregion


app.UseAuthorization();

 


app.MapControllers();

app.Run();


