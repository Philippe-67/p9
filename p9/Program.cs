using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using p9.Data;
using System.Net;
using System.Security.Claims;

namespace p9
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            var connectionString = builder.Configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");
            builder.Services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(connectionString));
            builder.Services.AddDatabaseDeveloperPageExceptionFilter();

            builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
                .AddRoles<IdentityRole>() // Ajout de la prise en charge des r�les
                .AddEntityFrameworkStores<ApplicationDbContext>();
            builder.Services.AddControllersWithViews();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
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
            app.UseAuthentication();//ajout du middleware d'authentification
            app.UseAuthorization();
            
           //app.Use(async (context, next) =>
           //{
           //    var userManager = context.RequestServices.GetRequiredService<UserManager<IdentityUser>>();
           //    var signInManager = context.RequestServices.GetRequiredService<SignInManager<IdentityUser>>();

           //    var user = await userManager.FindByEmailAsync("jacques@gmail.com");

           //    if (user != null && await userManager.IsInRoleAsync(user, "Administrateur"))
           //    {
           //        var result = await signInManager.PasswordSignInAsync(user, "Voir123!", false, lockoutOnFailure: false);

           //        if (result.Succeeded)
           //        {
           //            // Cr�er un claims principal pour l'utilisateur authentifi�
           //            var principal = await signInManager.CreateUserPrincipalAsync(user);

           //            // Ajouter le r�le d'administrateur aux claims de l'utilisateur
           //            ((ClaimsIdentity)principal.Identity).AddClaim(new Claim(ClaimTypes.Role, "Administrateur"));

           //            // Attribuer le claims principal � la requ�te
           //            context.User = principal;
           //        }
           //    }

           //    await next.Invoke();
           //});
           

            

            //// Appel pour initialiser les r�les
            //using (var scope = app.Services.CreateScope())
            //{
            //    var roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();
            //    RolesInitializer.InitializeAsync(roleManager).Wait();
            //}

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");
            app.MapRazorPages();

            app.Run();
        }
    }
}