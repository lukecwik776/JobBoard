using System;
using JobBoard.Areas.Identity.Data;
using JobBoard.Data;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

[assembly: HostingStartup(typeof(JobBoard.Areas.Identity.IdentityHostingStartup))]
namespace JobBoard.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            //builder.ConfigureServices((context, services) => {
            //    services.AddDbContext<ApplicationDbContext>(options =>
            //        options.UseSqlServer(
            //            context.Configuration.GetConnectionString("JobBoardIdentityDbContextConnection")));

            //    services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
            //        .AddEntityFrameworkStores<ApplicationDbContext>();
            //});
        }
    }
}