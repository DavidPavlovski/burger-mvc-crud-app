using BurgerWebApp.Domain;

namespace BurgerWebApp.DataAccess.Storage
{
    public static class BurgerDb
    {
        public static List<Burger> Burgers = new List<Burger>
        {
            new Burger("Breakfast burger" , "Bun , Sausage , Egg , Tomato , Letuce , Onions" , "https://food.fnr.sndimg.com/content/dam/images/food/fullset/2018/4/1/0/LS-Library_Breakfast-Sausage-Egg-Burger_s4x3.jpg.rend.hgtvcom.616.462.suffix/1522644655757.jpeg" , false ,false , 150),
            new Burger("Hamburger" , "Bun , Beef patty, Tomato ,Letuce , Onions" , "https://assets.epicurious.com/photos/57c5c6d9cf9e9ad43de2d96e/master/pass/the-ultimate-hamburger.jpg",false, false, 180),
            new Burger("Cheese Burger" , "Bun , Beef patty , Cheese , Tomato , Letuse , Onions" , "https://i.pinimg.com/originals/8b/61/11/8b611136ead0d4c247f0fef92925f284.jpg",false,false, 200),
            new Burger("Bacon Burger" , "Bun , Beef patty , Tomato , Letuce , Onions , Bacon" , "https://makeyourmeals.com/wp-content/uploads/2020/05/bacon-cheeseburger-featured-720x540.jpg",false,false , 250),
            new Burger("Double cheese burger" , "Bun , 2 x Beef patty , Tomato , Letuce , Onions, Cheese" , "https://www.hardees.com/-/media/project/cke/hardees/double-cheeseburger-705-x-401.jpgs",false,false , 250),
            new Burger("Double bacon cheese burger" , "Bun , 2 x Beef patty , Tomato , Letuce , Onions , Cheese , Bacon" , "https://groundbeefrecipes.com/wp-content/uploads/double-bacon-cheeseburger-recipe-6.jpg",false,false ,300),
            new Burger("Veggie Burger" , "Whole Wheat Bun Bun , Veggie patty , Tomato , Letuce , Onions" ,"https://i.ytimg.com/vi/a19EY3YNStA/maxresdefault.jpg", true, true , 120),
            new Burger("Zucchini Burger" , "Whole Wheat Bun , Zucchini patty , Tomato , Letuce , Cucumber , Oninons" , "https://img.sunset02.com/sites/default/files/styles/4_3_horizontal_-_900x675/public/zucchini-burgers-su.jpg" , false, true , 120)
        };

        public static List<Extra> Extras = new List<Extra>
        {
            new Extra("Small fries" , 30),
            new Extra("Large fries" , 60),
            new Extra("Small waffle fries" , 50),
            new Extra("Large waffle fries" , 80)
        };

        public static List<Order> Orders = new List<Order>();
    }
}
