using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using RamenKing.Models;
using Microsoft.AspNetCore.Identity;


namespace RamenKing.Data
{
    public class SeedData
    {
        public SeedData()
        {

        }

        public static async Task<Boolean> Initialize(IServiceProvider serviceProvider)
        {
           await  SeedUsers(serviceProvider);
           SeedRamen(serviceProvider);


            return true;


        }
        public static void SeedRamen(IServiceProvider serviceProvider)
        {
            using (var context = new AppDbContext(serviceProvider.GetRequiredService<DbContextOptions<AppDbContext>>()))
            {

                // Look for any Ramen.
                if (context.Ramens.Any())
                {
                    return ;   // DB has been seeded
                }
                context.Ramens.AddRange(
                new Ramen { Name = "Sapporo Miso Ramen", Price = 2000, ShortDescription = "Using chicken or pork bones combined with red miso to make the broth.", ImageURL = "/images/r1.jpeg", LongDescription = "On the northern island of Hokkaido, the city of Sapporo was the first to dream up their signature miso Ramen. Using chicken or pork bones combined with red miso to make the broth, you get a truly rich and heart-warming soup for those chilly weather days. This noodle and broth combo is topped with bean sprouts, butter, corn, leeks and as Hokkaido is home to major fishing ports, adding seafood to the soup is also common." },
                new Ramen { Name = "Wakayama Ramen", Price = 2200, ShortDescription = "From Shikoku Island", ImageURL = "/images/r2.webp", LongDescription = "From Shikoku Island, Wakayama Ramen uses a blend of tonkotsu and shoyu style broths to create something spectacular. Dark brown and delicious, this broth is topped with a raw egg and served with green onions, char siu, fish cakes, and menma. This dish is known locally as chuka soba which translates to Chinese soba." },
                new Ramen { Name = "Hakata Ramen", Price = 2000, ShortDescription = "Super straight noodles and a cloudy soup form the basis of Hakata ramen.", ImageURL = "/images/r3.jpeg", LongDescription = "Super straight noodles and a cloudy soup form the basis of Hakata ramen. This style of ramen originates from Fukuoka in Southern Japan. The tonkotsu bone broth is super silky and this dish needs minimal toppings as it's already drenched in flavor. Hakata was originally sold from food stalls to fishermen needing a quick hearty meal to fill them up. Now, Hakata ramen can be found around the globe as the Ippudo ramen shop went global. As the tonkotsu broth is full of amino acids and collagen from the bones, it’s also great for lining your digestive system and giving your immunity a boost." },
                new Ramen { Name = "Tsukemen", Price = 2000, ShortDescription = "This style of ramen originated in Tokyo by Kazuo Yamagishi.", ImageURL = "/images/r4.jpeg", LongDescription = "As mentioned, tsukemen separates the soup and the ramen noodles into different dishes, giving you the chance to grab a mouthful with your chopsticks and have fun with the dipping sauce element. This style of ramen originated in Tokyo by Kazuo Yamagishi. Usually, the noodles are cooked and then plunged into cold water so they retain their firmness and shape. The soup can be served hot or cold and tends to be pork based and full of intense flavors thanks to the seasoning. Dashi can also be added by the diner to dilute the intensity to match their palate." },
                new Ramen { Name = "Abura Soba", Price = 2030, ShortDescription = "Abura means oil in Japanese and soba is a style of noodles.", ImageURL = "/images/r5.jpeg", LongDescription = "Abura means oil in Japanese and soba is a style of noodles – so the name of this dish is oil noodles. What makes this style of ramen stand out from the crowd is the fact that it comes without any broth. However, this soupless ramen doesn’t scrimp on taste as it makes full use of making sure the ramen has a flavor bursting tare sauce. Despite the reference in the title to soba, this dish uses ramen noodles. The soba is a reference to the old Chinese name of these noodles - chuka soba. There are many different varieties of abura soba and it depends what region you are in as to what toppings and flavors you can expect. Usually, abura soba brings together chashu, egg yolk, nori, scallions, chili oil and seasoned ground pork with plenty of umami flavor." },
                new Ramen { Name = "Asahikawa Ramen", Price = 3100, ShortDescription = "A shoyu type ramen that comes from the city of the same name in Hokkaido.", ImageURL = "/images/r6.jpeg", LongDescription = "A shoyu type ramen that comes from the city of the same name in Hokkaido, asahikawa ramen is oily, complex, and delicious. Using wavy noodles, lots of soy sauce, and a broth made up of chicken, pork, and fish all add to the richness of this dish. Thanks to the fatty sheen that sits on top of this dish it also takes time to cool making it a must for those chilly northern days." },
                new Ramen { Name = "Hakodate Ramen", Price = 3100, ShortDescription = "A light and clear version of ramen that hails from the Hokkaido region.", ImageURL = "/images/r7.jpeg", LongDescription = "A light and clear version of ramen that hails from the Hokkaido region, hakodate takes its base from a pale and salty chicken broth seasoned with herbs. The noodles in this fragrant golden dish are straight and can either be medium or thin when it comes to thickness. Toppings include menma (bamboo shoots), char siu, spinach, corn, leeks, scallions, and naruto fish cake swirls.\n\n" },
                new Ramen { Name = "Kitakata Ramen", Price = 3100, ShortDescription = "This regional style of ramen hails from the city with the most ramen shops per capita.", ImageURL = "/images/r8.jpeg", LongDescription = "This regional style of ramen hails from the city with the most ramen shops per capita. Kitakata is a city in Fukushima and this local ramen is built upon a soy sauce base before being topped with fish cakes, green onions, char sui, and bamboo shoots. Along with a soy sauce broth there’s also niboshi (sardines), Tonkotsu, and sometimes vegetables or chicken to bring a little extra oomph and depth. Kitakata ramen also uses hirauchi jukusei takasuimen noodles that are thick and wavy and have a fabulously firm texture thanks to their lengthy maturing period.\n\n" },
                new Ramen { Name = "Sapporo Ramen", Price = 3100, ShortDescription = "Celebrated as being one of the three great ramens from the Hokkaido.", ImageURL = "/images/r9.jpeg", LongDescription = "Celebrated as being one of the three great ramens from the Hokkaido region, sapporo ramen is buttery and rich. A miso soybean base sets the scene along with the tonkotsu pork bone broth and the golden curly noodles. Add in some juicy char sui, bamboo shoots, green onions, and vegetables like cabbage, corn, and bean sprouts and you have a heart-warming combo. A melting pat of butter and seasonal seafood also make an appearance in sapporo ramen meaning every delicious box is well and truly ticked.\n\n" }
                );


                context.SaveChanges();
            }


        }

        public static async Task<IdentityResult> SeedUsers(IServiceProvider serviceProvider)
        {
            //Upsert Roles
            var roleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();
            var hasAdmin = await roleManager.RoleExistsAsync(UserRoles.Admin);
            if (!hasAdmin)
            {
               await roleManager.CreateAsync(new IdentityRole(UserRoles.Admin));
            }
            if (!await roleManager.RoleExistsAsync(UserRoles.User))
            {
               await roleManager.CreateAsync(new IdentityRole(UserRoles.User));
            }

            //Upsert Users
            var userManager = serviceProvider.GetRequiredService<UserManager<AppUser>>();
            if (await userManager.FindByEmailAsync("admin@ramenking.com") == null)
            {
                var newAdmin = new AppUser()
                {
                    UserName = "Admin",
                    Email = "admin@ramenking.com",
                    EmailConfirmed = true,
                    PostalAddress = "23 Ramen Street, Geelong, VIC"
,
                };
                await userManager.CreateAsync(newAdmin, "admin@Admin123");
                await userManager.AddToRoleAsync(newAdmin, UserRoles.Admin);
            }
            if (await userManager.FindByEmailAsync("user@ramenking.com") == null)
            {
                var newUser = new AppUser()
                {
                    UserName = "User",
                    Email = "user@ramenking.com",
                    EmailConfirmed = true,
                    PostalAddress = "999 Any Street, Geelong, VIC"
,
                };
                await userManager.CreateAsync(newUser, "user@User123");
                await userManager.AddToRoleAsync(newUser, UserRoles.User);
            }

            return IdentityResult.Success;

        }
    }
}

