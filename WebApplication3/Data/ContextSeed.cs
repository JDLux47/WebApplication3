using ASPNetCoreApp.Models;
using Microsoft.Extensions.Hosting;
using System.Reflection.Metadata;
using WebApplication3.Models;

namespace WebApplication3.Data
{
    public class ContextSeed
    {
        public static async Task SeedAsync(Context context)
        {
            try
            {
                context.Database.EnsureCreated();

                if (context.User.Any())
                {
                    return;
                }
                var users = new User[]
                {
                    new User{Name="Иванов Иван Иванович", Login = "Ivan123", Password = "12345678", Balance = 3300, DateUpdateBalance = DateTime.Now},
                    new User{Name="Петров Пётр Петрович", Login = "Petr97", Password = "12341234", Balance = 300, DateUpdateBalance = DateTime.Now},
                    new User{Name="Алексеев Алексей Алексеевич", Login = "Alex20", Password = "12121212", Balance = 35700, DateUpdateBalance = DateTime.Now}
                };
                foreach (User b in users)
                {
                    context.User.Add(b);
                }
                await context.SaveChangesAsync();
                var categories = new Category[]
                {
                    new Category { Name = "Транспорт"},
                    new Category { Name = "Продукты" }
                };
                foreach (Category p in categories)
                {
                    context.Category.Add(p);
                }
                await context.SaveChangesAsync();
                var transacts = new Transact[]
                {
                    new Transact { Sum = 150, Type = 1, Date = new DateTime(2023, 03, 14), CategoryId = 1, UserId = 1 },
                    new Transact { Sum = 100, Type = -1, Date = new DateTime(2023, 02, 07), CategoryId = 2, UserId = 2 }
                };
                foreach (Transact p in transacts)
                {
                    context.Transact.Add(p);
                }
                await context.SaveChangesAsync();

            }
            catch
            {
                throw;
            }
        }
    }
}