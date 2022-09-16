using ImmigrationApp.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

using ImmigrationApp.Permission;
using System;
using ImmigrationApp.Currentuser;
using ImmigrationApp.Repositries;
using ImmigrationApp.Extensions;
using ImmigrationApp.Hubs;

namespace ImmigrationApp
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddSingleton<IAuthorizationPolicyProvider, PermissionPolicyProvider>();
            services.AddScoped<IAuthorizationHandler, PermissionAuthorizationHandler>();
            //Custom Services
            services.AddTransient<ICurrentuser, Currentuser.Currentuser>();
            services.AddTransient<ICommonRepo, CommonRepo>();
            //services.AddTransient<ICompanyInfoRepo, CompanyInfoRepo>();
            services.AddTransient<IJobPostRepository, JobPostRepository>();
            //
            services.AddModule(Configuration);
            
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(
                    Configuration.GetConnectionString("DefaultConnection")));
            services.AddDatabaseDeveloperPageExceptionFilter();

            services.AddIdentity<IdentityUser<int>, IdentityRole<int>>()
                .AddDefaultUI()
                .AddRoles<IdentityRole<int>>()
                .AddRoleManager<RoleManager<IdentityRole<int>>>()
                .AddDefaultTokenProviders()
                .AddEntityFrameworkStores<ApplicationDbContext>();

            services.AddAuthentication().AddCookie(o =>
            {
                o.ExpireTimeSpan = TimeSpan.FromMinutes(30);
            });

            services.AddDistributedMemoryCache();
            services.AddSession(options =>
            {
                options.IdleTimeout = TimeSpan.FromMinutes(30);
                options.Cookie.HttpOnly = true;
                options.Cookie.IsEssential = true;
            });

            services.ConfigureApplicationCookie(options =>
            {
                options.LoginPath = $"/account/login";
                //options.LogoutPath = $"/account/logout";
                //options.AccessDeniedPath = $"/account/access-denied";
            });
            services.AddSignalR();
            services.AddMvc();
            //services.AddAuthentication()
            //    .AddGoogle(options =>
            //    {
            //        options.ClientId = "713982660465-tfh2h2ag2m0tt9e66onm686mbe913l8q.apps.googleusercontent.com";
            //        options.ClientSecret = "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";
            //    })
            //    .AddFacebook(options => {
            //        options.ClientId = "656864578732428";
            //        options.ClientSecret = "c16fede59476077ace3d5ce6ccbae201";
            //    });
            services.AddControllersWithViews();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseMigrationsEndPoint();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapHub<ChatHub>("/notify");
            });

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
                endpoints.MapRazorPages();
            });
        }
    }
}
