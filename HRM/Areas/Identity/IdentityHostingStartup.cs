using System;
using HRM.Areas.Identity.Data;
using HRM.Data;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

[assembly: HostingStartup(typeof(HRM.Areas.Identity.IdentityHostingStartup))]
namespace HRM.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) => {
                services.AddDbContext<HRMIdentityContext>(options =>
                    options.UseNpgsql(
                        context.Configuration.GetConnectionString("DefaultConnection")));

                services.AddDefaultIdentity<HRMUser>(options => options.SignIn.RequireConfirmedAccount = true)
                    .AddRoles<IdentityRole>()
                    .AddEntityFrameworkStores<HRMIdentityContext>();
                services.AddScoped<AuthenticationStateProvider, RevalidatingIdentityAuthenticationStateProvider<HRMUser>>();
                services.Configure<IdentityOptions>(options =>
                {
                    options.Password.RequireNonAlphanumeric = false;

                    options.User.RequireUniqueEmail = true;
                    options.User.AllowedUserNameCharacters = String.Empty;
                });
            });
        }
    }
}