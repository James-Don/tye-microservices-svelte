//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using Microsoft.AspNetCore.Authentication;
//using Microsoft.AspNetCore.Authentication.JwtBearer;
//using Microsoft.AspNetCore.Authorization;
//using Microsoft.AspNetCore.Builder;
//using Microsoft.AspNetCore.Hosting;
//using Microsoft.AspNetCore.Http;
//using Microsoft.AspNetCore.Identity;
//using Microsoft.Extensions.DependencyInjection;
//using Microsoft.Extensions.Hosting;
//using Microsoft.IdentityModel.Tokens;

//namespace inflation_machine
//{
//    public class Startup
//    {
//        // This method gets called by the runtime. Use this method to add services to the container.
//        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
//        public void ConfigureServices(IServiceCollection services)
//        {
//            services.AddCors();

//            //services.AddControllers
//            services.AddRazorPages();

//            services.AddControllersWithViews();

//            services.Configure<IdentityOptions>(options =>
//            {
//                // Password settings.
//                options.Password.RequireDigit = true;
//                options.Password.RequireLowercase = true;
//                options.Password.RequireNonAlphanumeric = true;
//                options.Password.RequireUppercase = true;
//                options.Password.RequiredLength = 6;
//                options.Password.RequiredUniqueChars = 1;

//                // Lockout settings.
//                options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(5);
//                options.Lockout.MaxFailedAccessAttempts = 5;
//                options.Lockout.AllowedForNewUsers = true;

//                // User settings.
//                options.User.AllowedUserNameCharacters =
//                "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789-._@+";
//                options.User.RequireUniqueEmail = false;
//            });

//            services.ConfigureApplicationCookie(options =>
//            {
//                // Cookie settings
//                options.Cookie.HttpOnly = true;
//                options.ExpireTimeSpan = TimeSpan.FromMinutes(5);

//                options.LoginPath = "/Identity/Account/Login";
//                options.AccessDeniedPath = "/Identity/Account/AccessDenied";
//                options.SlidingExpiration = true;
//            });

            
//            //services.AddIdentityServer()
//            //    .AddApiAuthorization<IdentityUser, inflationContext>();

//            //services.AddAuthentication()
//            //    .AddIdentityServerJwt();


//            services.AddAuthorization(options =>
//            {
//                options.FallbackPolicy = new AuthorizationPolicyBuilder()
//                    .RequireAuthenticatedUser()
//                    .Build();
//            });
//        }

//        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
//        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
//        {
//            if (env.IsDevelopment())
//            {
//                app.UseDeveloperExceptionPage();
//            }

//            app.UseCors(options =>
//            {
//                options.AllowAnyMethod().AllowAnyHeader();
//                options.SetIsOriginAllowed((host) => true);
//                options.AllowCredentials();
//            });

//            app.UseDefaultFiles();
//            app.UseStaticFiles();
//            app.UseRouting();
//            app.UseHttpsRedirection();
//            app.UseAuthentication();
//            app.UseAuthorization();


//            app.UseEndpoints(endpoints =>
//            {
//                endpoints.MapControllers();
//                endpoints.MapRazorPages();                
//                endpoints.MapControllerRoute(name: "default", pattern: "{controller}/{action=Index}/{id?}");
//                endpoints.MapFallbackToFile("index.html").AllowAnonymous();
//            });
//        }
//    }
//}
