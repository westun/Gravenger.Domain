using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using Gravenger.Domain.Core.Models;

namespace Gravenger.Domain.Persistence
{
    public class GravengerDBInitializer : DropCreateDatabaseIfModelChanges<GravengerContext>
    {
        protected override void Seed(GravengerContext context)
        {
            List<Category> categories = this.GetCategories().ToList();
            categories.ForEach(c => context.Categories.AddOrUpdate(category => category.Title, c));
            context.SaveChanges();

            List<Card> cards = this.GetCards(context).ToList();
            cards.ForEach(c => context.Cards.AddOrUpdate(card => card.Title, c));
            context.SaveChanges();

            //var accounts = new List<Account>{
            //    new Account{
            //        Username = "westun", Email = "wesleytunnermann@gmail.com", FirstName = "Wesley", LastName = "Tunnermann", Password = "password",
            //        Roles = new List<Role>{
            //            new Role{ Name = "Admin" },
            //        }
            //    },
            //};

            //context.Accounts.AddRange(accounts);
            //context.SaveChanges();

        }

        private IEnumerable<Category> GetCategories()
        {
            return new List<Category>
            {
                new Category { Title = "New", },
                new Category { Title = "Popular", },
                new Category { Title = "Fun", },
                new Category { Title = "Travel", },
                new Category { Title = "Culture", },
                new Category { Title = "Food & Drink", },
                new Category { Title = "Friends+Fam", },
                new Category { Title = "Lifestyle", },
            };
        }

        private IEnumerable<Card> GetCards(GravengerContext context)
        {
            IEnumerable<Category> categories = context.Categories.ToArray();

            return new List<Card>
            {
                new Card
                {
                    Title = "Netflix & chill",
                    Category = categories.FirstOrDefault(c => c.Title == "New"),
                    Tiles = new Tile[]
                    {
                        new Tile { Title = "Domino's pizza", Position = 1 },
                        new Tile { Title = "pajamas", Position = 2 },
                        new Tile { Title = "bae", Position = 3 },
                        new Tile { Title = "popcorn", Position = 4 },
                        new Tile { Title = "cuddling", Position = 5 },
                        new Tile { Title = "Pepsi", Position = 6 },
                        new Tile { Title = "binge", Position = 7 },
                        new Tile { Title = "Netflix", Position = 8 },
                        new Tile { Title = "chill", Position = 9 },
                    }
                },
                new Card
                {
                    Title = "haul H&M",
                    Category = categories.FirstOrDefault(c => c.Title == "New"),
                    Tiles = new Tile[]
                    {
                        new Tile { Title = "sweater", Position = 1 },
                        new Tile { Title = "jewelry", Position = 2 },
                        new Tile { Title = "bomber jacket", Position = 3 },
                        new Tile { Title = "flannel shirt", Position = 4 },
                        new Tile { Title = "crop top", Position = 5 },
                        new Tile { Title = "leggings", Position = 6 },
                        new Tile { Title = "booties", Position = 7 },
                        new Tile { Title = "skinny jeans", Position = 8 },
                        new Tile { Title = "midi skirt", Position = 9 },
                    }
                },
                new Card
                {
                    Title = "Baking",
                    Category = categories.FirstOrDefault(c => c.Title == "Food & Drink"),
                    Tiles = new Tile[]
                    {
                        new Tile { Title = "Chocolate chip cookies", Position = 1 },
                        new Tile { Title = "Vanilla cupcakes", Position = 2 },
                        new Tile { Title = "Amadines", Position = 3 },
                        new Tile { Title = "Apple pie", Position = 4 },
                        new Tile { Title = "Oreo cheesecake", Position = 5 },
                        new Tile { Title = "Sugar cookies", Position = 6 },
                        new Tile { Title = "Caramel cupcakes", Position = 7 },
                        new Tile { Title = "World peace cookies", Position = 8 },
                        new Tile { Title = "Popcorn cookies", Position = 9 },
                    }
                },
                new Card
                {
                    Title = "New York",
                    Category = categories.FirstOrDefault(c => c.Title == "Travel"),
                    Tiles = new Tile[]
                    {
                        new Tile { Title = "Pumpkin Spice Latte", Position = 1 },
                        new Tile { Title = "Flat white", Position = 2 },
                        new Tile { Title = "Frappuccino", Position = 3 },
                        new Tile { Title = "Gingerbread Latte", Position = 4 },
                        new Tile { Title = "Creme Brulee Latte", Position = 5 },
                        new Tile { Title = "White Chocolate Mocha", Position = 6 },
                        new Tile { Title = "Peppermint Mocha", Position = 7 },
                        new Tile { Title = "Pike Place Roast", Position = 8 },
                        new Tile { Title = "Barista's choice", Position = 9 },
                    }
                },
                new Card
                {
                    Title = "Starbucks",
                    Category = categories.FirstOrDefault(c => c.Title == "Food & Drink"),
                    Tiles = new Tile[]
                    {
                        new Tile { Title = "Pumpkin Spice Latte", Position = 1 },
                        new Tile { Title = "Flat White", Position = 2 },
                        new Tile { Title = "Frappuccino", Position = 3 },
                        new Tile { Title = "Gingerbread Latte", Position = 4 },
                        new Tile { Title = "Creme Brulee Latte", Position = 5 },
                        new Tile { Title = "White Chocolate Mocha", Position = 6 },
                        new Tile { Title = "Peppermint Mocha", Position = 7 },
                        new Tile { Title = "Pike Place Roast", Position = 8 },
                        new Tile { Title = "Barista's Choice", Position = 9 },
                    }
                },

                //new Card
                //{
                //    Title = "",
                //    Category = categories.FirstOrDefault(c => c.Title == ""),
                //    Tiles = new Tile[]
                //    {
                //        new Tile { Title = "", Position = 1 },
                //        new Tile { Title = "", Position = 2 },
                //        new Tile { Title = "", Position = 3 },
                //        new Tile { Title = "", Position = 4 },
                //        new Tile { Title = "", Position = 5 },
                //        new Tile { Title = "", Position = 6 },
                //        new Tile { Title = "", Position = 7 },
                //        new Tile { Title = "", Position = 8 },
                //        new Tile { Title = "", Position = 9 },
                //    }
                //},

            };
        }

    }
}