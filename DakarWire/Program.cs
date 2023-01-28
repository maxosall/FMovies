using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using DakarWire.Areas.Identity;
using DakarWire.Data;
using Tailwind;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);
var configuration = builder.Configuration;
// Add services to the container.
string connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlite(connectionString));
builder.Services.AddDatabaseDeveloperPageExceptionFilter();
builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
    .AddEntityFrameworkStores<ApplicationDbContext>();

builder.Services.Configure<IdentityOptions>(options => {
    // Password
    options.Password.RequiredLength =6;
    options.Password.RequireLowercase = true;
    options.Password.RequireUppercase = true;
    options.Password.RequireDigit = true;

    // Lockout
    options.Lockout.MaxFailedAccessAttempts = 3;
    // options.Lockout.AllowedForNewUsers = true;

    // User
    options.User.RequireUniqueEmail = true;
});

builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services.AddScoped<AuthenticationStateProvider, RevalidatingIdentityAuthenticationStateProvider<IdentityUser>>();
builder.Services.AddSingleton<WeatherForecastService>();

builder.Services.AddAuthentication()
   .AddGoogle(options =>
   {
       IConfigurationSection googleAuthNSection =
       configuration.GetSection("Authentication:Google");
       options.ClientId = googleAuthNSection["ClientId"];
       options.ClientSecret = googleAuthNSection["ClientSecret"];
   })
   .AddFacebook(facebookOptions =>
    {
        facebookOptions.AppId = configuration["Authentication:Facebook:AppId"];
        facebookOptions.AppSecret = configuration["Authentication:Facebook:AppSecret"];
    });

WebApplication app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.RunTailwind("tailwind", "./wwwroot");

    app.UseMigrationsEndPoint();
}
else
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();
app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.Run();

/*
    dotnet new blazorwasm -au Individual -ho -o {APP NAME}

dotnet add package Microsoft.VisualStudio.Web.CodeGeneration.Design
dotnet tool install -g dotnet-aspnet-codegenerator

dotnet add package Microsoft.VisualStudio.Web.CodeGeneration.Design
dotnet add package Microsoft.EntityFrameworkCore.Design
dotnet add package Microsoft.AspNetCore.Identity.EntityFrameworkCore
dotnet add package Microsoft.AspNetCore.Identity.UI
dotnet add package Microsoft.EntityFrameworkCore.SqlServer
dotnet add package Microsoft.EntityFrameworkCore.Tools

dotnet aspnet-codegenerator identity -h
dotnet aspnet-codegenerator identity -dc DakarWire.Data.ApplicationDbContext --files "Account._StatusMessage;Account.AccessDenied;Account.ConfirmEmail;Account.ConfirmEmailChange;Account.ExternalLogin;Account.ForgotPassword;Account.ForgotPasswordConfirmation;Account.Lockout;Account.Login;Account.LoginWith2fa;Account.LoginWithRecoveryCode;Account.Logout;Account.Manage._Layout;Account.Manage._ManageNav;Account.Manage._StatusMessage;Account.Manage.ChangePassword;Account.Manage.DeletePersonalData;Account.Manage.Disable2fa;Account.Manage.DownloadPersonalData;Account.Manage.Email;Account.Manage.EnableAuthenticator;Account.Manage.ExternalLogins;Account.Manage.GenerateRecoveryCodes;Account.Manage.Index;Account.Manage.PersonalData; 
Account.Manage.SetPassword; Account.Manage.ResetAuthenticator; Account.Manage.ShowRecoveryCodes; Account.Manage.TwoFactorAuthentication; Account.Register; Account.RegisterConfirmation;Account.ResendEmailConfirmation;Account.ResetPassword;Account.ResetPasswordConfirmation"
*/