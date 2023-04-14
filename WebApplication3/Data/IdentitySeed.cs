using Microsoft.AspNetCore.Identity;
using WebApplication3.Models;

namespace WebApplication3.Data
{
    public static class IdentitySeed
    {
        public static async Task CreateUserRoles(IServiceProvider serviceProvider)
        {
            var roleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole<int>>>();
            var userManager = serviceProvider.GetRequiredService<UserManager<User>>();

            // Создание ролей администратора и пользователя
            if (await roleManager.FindByNameAsync("admin") == null)
            {
                await roleManager.CreateAsync(new IdentityRole<int>("admin"));
            }
            if (await roleManager.FindByNameAsync("user") == null)
            {
                await roleManager.CreateAsync(new IdentityRole<int>("user"));
            }

            // Создание Администратора
            string adminLogin = "admin";
            string adminPassword = "Aa123456!";
            string adminName = "Владислав Алексеевич Администраторов";
            if (await userManager.FindByNameAsync(adminLogin) == null)
            {
                User admin = new User { Login = adminLogin, UserName = adminLogin, Password = adminPassword, Name = adminName };
                IdentityResult result = await userManager.CreateAsync(admin, adminPassword);
                if (result.Succeeded)
                {
                    await userManager.AddToRoleAsync(admin, "admin");
                }
            }

            // Создание Пользователя
            string userLogin = "user";
            string userPassword = "Aa123456!";
            string userName = "Дмитрий Александрович Пользователев";
            if (await userManager.FindByNameAsync(userLogin) == null)
            {
                User user = new User { Login = userLogin, Password = userPassword, UserName = userLogin, Name = userName };
                IdentityResult result = await userManager.CreateAsync(user, userPassword);
                if (result.Succeeded)
                {
                    await userManager.AddToRoleAsync(user, "user");
                }
            }
        }
    }
}
