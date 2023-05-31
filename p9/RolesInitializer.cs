
//using Microsoft.AspNetCore.Identity;

//public static class RolesInitializer
//{
//    public static async Task InitializeAsync(RoleManager<IdentityRole> roleManager)
//    {
//        string[] roles = { "Visiteur", "Administrateur" };

//        foreach (var role in roles)
//        {
//            if (!await roleManager.RoleExistsAsync(role))
//            {
//                await roleManager.CreateAsync(new IdentityRole(role));
//            }
//        }
//    }
//}