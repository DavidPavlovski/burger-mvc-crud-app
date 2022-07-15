using BurgerWebApp.Domain;
using Microsoft.EntityFrameworkCore;

namespace BurgerWebApp.DataAccess
{
    public class BurgerWebAppDbContext : DbContext
    {
        public DbSet<Burger> Burgers { get; set; }
        public DbSet<Extra> Extras { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Location> Locations { get; set; }
        public DbSet<BurgerOrderItem> BurgerOrderItems { get; set; }
        public DbSet<ExtraOrderItem> ExtraOrderItems { get; set; }
        public BurgerWebAppDbContext(DbContextOptions<BurgerWebAppDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Burger>(x => x.ToTable("Burger"));
            builder.Entity<Extra>(x => x.ToTable("Extra"));
            builder.Entity<Order>(x => x.ToTable("Order"));
            builder.Entity<Location>(x => x.ToTable("Location"));
            builder.Entity<BurgerOrderItem>(x => x.ToTable("BurgerOrderItem"));
            builder.Entity<ExtraOrderItem>(x => x.ToTable("ExtraOrderItem"));

            builder.Entity<Burger>().HasData
            (
                new Burger("Breakfast burger", "Bun , Sausage , Egg , Tomato , Letuce , Onions", "https://food.fnr.sndimg.com/content/dam/images/food/fullset/2018/4/1/0/LS-Library_Breakfast-Sausage-Egg-Burger_s4x3.jpg.rend.hgtvcom.616.462.suffix/1522644655757.jpeg", false, false, 150) { Id = 1 },
                new Burger("Hamburger", "Bun , Beef patty, Tomato ,Letuce , Onions", "https://assets.epicurious.com/photos/57c5c6d9cf9e9ad43de2d96e/master/pass/the-ultimate-hamburger.jpg", false, false, 180) { Id = 2 },
                new Burger("Cheese Burger", "Bun , Beef patty , Cheese , Tomato , Letuse , Onions", "https://i.pinimg.com/originals/8b/61/11/8b611136ead0d4c247f0fef92925f284.jpg", false, false, 200) { Id = 3 },
                new Burger("Bacon Burger", "Bun , Beef patty , Tomato , Letuce , Onions , Bacon", "https://makeyourmeals.com/wp-content/uploads/2020/05/bacon-cheeseburger-featured-720x540.jpg", false, false, 250) { Id = 4 },
                new Burger("Double cheese burger", "Bun , 2 x Beef patty , Tomato , Letuce , Onions, Cheese", "https://www.hardees.com/-/media/project/cke/hardees/double-cheeseburger-705-x-401.jpgs", false, false, 250) { Id = 5 },
                new Burger("Double bacon cheese burger", "Bun , 2 x Beef patty , Tomato , Letuce , Onions , Cheese , Bacon", "https://groundbeefrecipes.com/wp-content/uploads/double-bacon-cheeseburger-recipe-6.jpg", false, false, 300) { Id = 6 },
                new Burger("Veggie Burger", "Whole Wheat Bun Bun , Veggie patty , Tomato , Letuce , Onions", "https://i.ytimg.com/vi/a19EY3YNStA/maxresdefault.jpg", true, true, 120) { Id = 7 },
                new Burger("Zucchini Burger", "Whole Wheat Bun , Zucchini patty , Tomato , Letuce , Cucumber , Oninons", "https://img.sunset02.com/sites/default/files/styles/4_3_horizontal_-_900x675/public/zucchini-burgers-su.jpg", false, true, 120) { Id = 8 }
            );

            builder.Entity<Extra>().HasData
            (
                new Extra("Small fries", 30) { Id = 1 },
                new Extra("Large fries", 60) { Id = 2 },
                new Extra("Small waffle fries", 50) { Id = 3 },
                new Extra("Large waffle fries", 80) { Id = 4 }
            );
            builder.Entity<Location>().HasData
            (
                new Location("Dacos burgers Skopje Centar", "Partizanski orderdi", 8, 22) { Id = 1 },
                new Location("Dacos burgers Skopje Aerodrom", "Jane Sandanski", 8, 22) { Id = 2 },
                new Location("Dacos burgers Ohrid", "7mi Noemvri", 8, 22) { Id = 3 },
                new Location("Dacos burgers Bitola", "Ilindenska", 8, 22) { Id = 4 }
           );
        }
    }
}
