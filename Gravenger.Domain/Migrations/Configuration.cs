using Gravenger.Domain.Core.Models;
using Gravenger.Domain.Persistence;

namespace Gravenger.Domain.Migrations
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<GravengerContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            ContextKey = "Gravenger.Domain.Migrations.Configuration";
        }

        protected override void Seed(GravengerContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.

            //TODO: Seeding data this way should only be done locally for testing
            //      To properly seed data write migration scripts that contain the SQL to insert, update, or remove records

            //this.SeedCategories(context);
            //context.SaveChanges();

            //this.SeedCards(context);
            //context.SaveChanges();

            //this.SeedRoles(context);
            //context.SaveChanges();
        }
        
        private void SeedRoles(GravengerContext context)
        {
            context.Roles.AddOrUpdate(r => r.Name, new Role[]
            {
                new Role{ Name = "Admin" },
                new Role{ Name = "Can Manage Permissions" },
                new Role{ Name = "Can Manage Account Permissions" },
                new Role{ Name = "Can Manage Cards" },
                new Role{ Name = "Can Create Invitations" },
                new Role{ Name = "Can Manage Account Photos" },
            });
        }

        private void SeedCategories(GravengerContext context)
        {
            context.Categories.AddOrUpdate(c => c.Title,
                new Category { Title = "New", },
                new Category { Title = "Popular", },
                new Category { Title = "Fun", },
                new Category { Title = "Travel", },
                new Category { Title = "Culture", },
                new Category { Title = "Food & Drink", },
                new Category { Title = "Friends+Fam", },
                new Category { Title = "Lifestyle", });
        }

        private void SeedCards(GravengerContext context)
        {
            context.Cards.AddOrUpdate(c => c.Title,
                new Card
                {
                    Title = "Netflix & chill",
                    Category = context.Categories.FirstOrDefault(c => c.Title == "New"),
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
                    Category = context.Categories.FirstOrDefault(c => c.Title == "New"),
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
                    Category = context.Categories.FirstOrDefault(c => c.Title == "Food & Drink"),
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
                    Category = context.Categories.FirstOrDefault(c => c.Title == "Travel"),
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
                    Category = context.Categories.FirstOrDefault(c => c.Title == "Food & Drink"),
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
                });

            //new Card
            //{
            //    Title = "",
            //    Category = context.Categories.FirstOrDefault(c => c.Title == ""),
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


        }
    }
}
