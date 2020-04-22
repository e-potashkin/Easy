using System.Linq;
using System.Threading.Tasks;
using Easy.Domain.Entities;
using Microsoft.AspNetCore.Identity;

namespace Easy.Infrastructure.Data
{
    public static class ApplicationDbContextSeed
    {
        public static async Task SeedDefaultUserAsync(UserManager<User> userManager)
        {
            var defaultUser = new User {FirstName = "Johnny", LastName = "Cage"};

            if (userManager.Users.All(u => u.FirstName != defaultUser.FirstName))
            {
                await userManager.CreateAsync(defaultUser, "Administrator1!");
            }
        }

        // public static async Task SeedSampleDataAsync(DataContext context)
        // {
        //     // Seed, if necessary
        //     if (!context.TodoLists.Any())
        //     {
        //         context.TodoLists.Add(new TodoList
        //         {
        //             Title = "Shopping",
        //             Items =
        //             {
        //                 new TodoItem {Title = "Apples", Done = true},
        //                 new TodoItem {Title = "Milk", Done = true},
        //                 new TodoItem {Title = "Bread", Done = true},
        //                 new TodoItem {Title = "Toilet paper"},
        //                 new TodoItem {Title = "Pasta"},
        //                 new TodoItem {Title = "Tissues"},
        //                 new TodoItem {Title = "Tuna"},
        //                 new TodoItem {Title = "Water"}
        //             }
        //         });
        //
        //         await context.SaveChangesAsync();
        //     }
        // }
    }
}