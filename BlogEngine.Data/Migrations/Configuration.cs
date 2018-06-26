namespace BlogEngine.Data.Migrations
{
    using BlogEngine.Data;
    using BlogEngine.Model.Models;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<BlogEngineDbContext>
    {
        #region Configuration
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }
        #endregion

        #region Seed
        protected override void Seed(BlogEngineDbContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.

            CategorySeedData(context);
            SubCategorySeedData(context);
            PostSeedData(context);
        }
        #endregion

        #region Category Seed Data
        private void CategorySeedData(BlogEngineDbContext context)
        {
            if (context.Categories.Count() == 0)
            {
                List<Category> categories = new List<Category>()
                {
                    new Category()
                    {
                        ID = 1,
                        Name = "C# Programming",
                        Slug = "csharp",
                        Image = "",
                        CreatedDate = DateTime.Now,
                        CreatedBy = "khanh.buivuong@nashtechglobal.com"
                    },
                    new Category()
                    {
                        ID = 2,
                        Name = "ASP.NET Core",
                        Slug = "asp.net-core",
                        Image = "",
                        CreatedDate = DateTime.Now,
                        CreatedBy = "khanh.buivuong@nashtechglobal.com"
                    },
                    new Category()
                    {
                        ID = 3,
                        Name = "ASP.NET Web Application",
                        Slug = "asp.net-web-application",
                        Image = "",
                        CreatedDate = DateTime.Now,
                        CreatedBy = "khanh.buivuong@nashtechglobal.com"
                    },
                    new Category()
                    {
                        ID = 4,
                        Name = "Windows Desktop Application",
                        Slug = "windows-desktop-application",
                        Image = "",
                        CreatedDate = DateTime.Now,
                        CreatedBy = "khanh.buivuong@nashtechglobal.com"
                    },
                    new Category()
                    {
                        ID = 5,
                        Name = "HTML, CSS & Boostrap",
                        Slug = "html-css-boostrap",
                        Image = "",
                        CreatedDate = DateTime.Now,
                        CreatedBy = "khanh.buivuong@nashtechglobal.com"
                    },
                    new Category()
                    {
                        ID = 6,
                        Name = "Javascript Frameworks",
                        Slug = "javascript-framework",
                        Image = "",
                        CreatedDate = DateTime.Now,
                        CreatedBy = "khanh.buivuong@nashtechglobal.com"
                    },
                    new Category()
                    {
                        ID = 7,
                        Name = "Entity FrameWork 6/Entity FrameWork Core",
                        Slug = "entity-framework",
                        Image = "",
                        CreatedDate = DateTime.Now,
                        CreatedBy = "khanh.buivuong@nashtechglobal.com"
                    },
                    new Category()
                    {
                        ID = 8,
                        Name = "Database",
                        Slug = "database",
                        Image = "",
                        CreatedDate = DateTime.Now,
                        CreatedBy = "khanh.buivuong@nashtechglobal.com"
                    },
                    new Category()
                    {
                        ID = 9,
                        Name = "Security",
                        Slug = "security",
                        Image = "",
                        CreatedDate = DateTime.Now,
                        CreatedBy = "khanh.buivuong@nashtechglobal.com"
                    },
                };
                context.Categories.AddRange(categories);
                context.SaveChanges();
            }
        }
        #endregion

        #region Sub Category Seed Data
        private void SubCategorySeedData(BlogEngineDbContext context)
        {
            List<SubCategory> subCategories = new List<SubCategory>()
            {
                new SubCategory()
                {
                    Name = "ASP.NET MVC5",
                    Slug = "asp.net-mvc5",
                    CategoryID = 3,
                    CreatedDate = DateTime.Now,
                    CreatedBy = "khanh.buivuong@nashtechglobal.com"
                },
                new SubCategory()
                {
                    Name = "ASP.NET MVC Core",
                    Slug = "asp.net-mvc-core",
                    CategoryID = 2,
                    CreatedDate = DateTime.Now,
                    CreatedBy = "khanh.buivuong@nashtechglobal.com"
                },
                new SubCategory()
                {
                    Name = "ASP.NET Web Form",
                    Slug = "asp.net-web-form",
                    CategoryID = 3,
                    CreatedDate = DateTime.Now,
                    CreatedBy = "khanh.buivuong@nashtechglobal.com"
                },
                new SubCategory()
                {
                    Name = "NET Windows Form",
                    Slug = "winform",
                    CategoryID = 4,
                    CreatedDate = DateTime.Now,
                    CreatedBy = "khanh.buivuong@nashtechglobal.com"
                },
                new SubCategory()
                {
                    Name = "Windows Presentation Foundation",
                    Slug = "winform-presentation-foundataion",
                    CategoryID = 4,
                    CreatedDate = DateTime.Now,
                    CreatedBy = "khanh.buivuong@nashtechglobal.com"
                },
                new SubCategory()
                {
                    Name = "JQuery",
                    Slug = "jquery",
                    CategoryID = 6,
                    CreatedDate = DateTime.Now,
                    CreatedBy = "khanh.buivuong@nashtechglobal.com"
                },
                new SubCategory()
                {
                    Name = "KnockoutJS",
                    Slug = "knockoutjs",
                    CategoryID = 6,
                    CreatedDate = DateTime.Now,
                    CreatedBy = "khanh.buivuong@nashtechglobal.com"
                },
                new SubCategory()
                {
                    Name = "Angularjs",
                    Slug = "angularjs",
                    CategoryID = 6,
                    CreatedDate = DateTime.Now,
                    CreatedBy = "khanh.buivuong@nashtechglobal.com"
                },
                new SubCategory()
                {
                    Name = "Angular 5",
                    Slug = "angular5",
                    CategoryID = 6,
                    CreatedDate = DateTime.Now,
                    CreatedBy = "khanh.buivuong@nashtechglobal.com"
                },
                new SubCategory()
                {
                    Name = "Reactjs",
                    Slug = "Reactjs",
                    CategoryID = 6,
                    CreatedDate = DateTime.Now,
                    CreatedBy = "khanh.buivuong@nashtechglobal.com"
                },
                new SubCategory()
                {
                    Name = "Vuejs",
                    Slug = "vuejs",
                    CategoryID = 6,
                    CreatedDate = DateTime.Now,
                    CreatedBy = "khanh.buivuong@nashtechglobal.com"
                },
                new SubCategory()
                {
                    Name = "My SQL",
                    Slug = "mysql",
                    CategoryID = 8,
                    CreatedDate = DateTime.Now,
                    CreatedBy = "khanh.buivuong@nashtechglobal.com"
                },
                new SubCategory()
                {
                    Name = "Microsoft SQL Server",
                    Slug = "microsoft-sql-server",
                    CategoryID = 8,
                    CreatedDate = DateTime.Now,
                    CreatedBy = "khanh.buivuong@nashtechglobal.com"
                },
                new SubCategory()
                {
                    Name = "Oracle",
                    Slug = "oracle",
                    CategoryID = 8,
                    CreatedDate = DateTime.Now,
                    CreatedBy = "khanh.buivuong@nashtechglobal.com"
                },
                new SubCategory()
                {
                    Name = "Object Oriented Programming",
                    Slug = "oop",
                    CategoryID = 1,
                    CreatedDate = DateTime.Now,
                    CreatedBy = "khanh.buivuong@nashtechglobal.com"
                },
            };
            context.SubCategories.AddRange(subCategories);
            context.SaveChanges();
        }
        #endregion

        #region Post Seed Data
        private void PostSeedData(BlogEngineDbContext context)
        {
            List<Post> posts = new List<Post>()
            {
                new Post()
                {
                    Name = "Introducing Nullable Reference Types in C#",
                    Slug = "introducing-nullable-reference-types-in-csharp",
                    CategoryID = 1,
                    Summary = "Today we released a prototype of a C# feature called “nullable reference types“, which is intended to help you find and fix most of your null-related bugs before they blow up at runtime. We would love for you to install the prototype and try it out on your code! (Or maybe a copy of it!",
                    CreatedDate = DateTime.Now,
                    CreatedBy = "khanh.buivuong@nashtechglobal.com",
                    SubCategoryID = 15
                },
                new Post()
                {
                    Name = ".NET Core 2.1 June Update",
                    Slug = "net-core-2-1-june-update",
                    CategoryID = 2,
                    Summary=@"We released .NET Core 2.1.1. This update includes .NET Core SDK 2.1.301, ASP.NET Core 2.1.1 and .NET Core 2.1.1. See .NET Core 2.1.1 release notes for complete details on the release. Quality Updates CLI [4050c6374] The “pack” command under ‘buildCrossTargeting’ for ‘Microsoft.DotNet.MSBuildSdkResolver’ now throws a “NU5104” warning/error because the SDK stage0 was changed to “2.1.300” [change was",
                    CreatedDate = DateTime.Now,
                    CreatedBy = "khanh.buivuong@nashtechglobal.com",
                    SubCategoryID = 2
                }
            };
            context.Posts.AddRange(posts);
            context.SaveChanges();
        }
        #endregion

        #region Tag Seed Data
        private void TagSeedData(BlogEngineDbContext context)
        {
            if (context.Tags.Count() == 0)
            {
                List<Tag> tags = new List<Tag>()
                {
                    new Tag()
                    {

                    }
                };
                context.Tags.AddRange(tags);
                context.SaveChanges();
            }
        }
        #endregion

        #region Post Tag Seed Data
        private void PostTagSeedData(BlogEngineDbContext context)
        {
            if (context.PostTags.Count() == 0)
            {
                List<PostTag> postTags = new List<PostTag>()
                {
                    new PostTag()
                    {

                    }
                };
                context.PostTags.AddRange(postTags);
                context.SaveChanges();
            }
        }
        #endregion
    }
}


