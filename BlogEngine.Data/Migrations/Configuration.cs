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
                        CreatedBy = "khanh.buivuong@nashtechglobal.com",
                        Status = true
                    },
                    new Category()
                    {
                        ID = 2,
                        Name = "ASP.NET Core",
                        Slug = "asp.net-core",
                        Image = "",
                        CreatedDate = DateTime.Now,
                        CreatedBy = "khanh.buivuong@nashtechglobal.com",
                        Status = true
                    },
                    new Category()
                    {
                        ID = 3,
                        Name = "ASP.NET Web Application",
                        Slug = "asp.net-web-application",
                        Image = "",
                        CreatedDate = DateTime.Now,
                        CreatedBy = "khanh.buivuong@nashtechglobal.com",
                        Status = true
                    },
                    new Category()
                    {
                        ID = 4,
                        Name = "Windows Desktop Application",
                        Slug = "windows-desktop-application",
                        Image = "",
                        CreatedDate = DateTime.Now,
                        CreatedBy = "khanh.buivuong@nashtechglobal.com",
                        Status = true
                    },
                    new Category()
                    {
                        ID = 5,
                        Name = "HTML, CSS & Boostrap",
                        Slug = "html-css-boostrap",
                        Image = "",
                        CreatedDate = DateTime.Now,
                        CreatedBy = "khanh.buivuong@nashtechglobal.com",
                        Status = true
                    },
                    new Category()
                    {
                        ID = 6,
                        Name = "Javascript Frameworks",
                        Slug = "javascript-framework",
                        Image = "",
                        CreatedDate = DateTime.Now,
                        CreatedBy = "khanh.buivuong@nashtechglobal.com",
                        Status = true
                    },
                    new Category()
                    {
                        ID = 7,
                        Name = "Entity FrameWork 6/Entity FrameWork Core",
                        Slug = "entity-framework",
                        Image = "",
                        CreatedDate = DateTime.Now,
                        CreatedBy = "khanh.buivuong@nashtechglobal.com",
                        Status = true
                    },
                    new Category()
                    {
                        ID = 8,
                        Name = "Database",
                        Slug = "database",
                        Image = "",
                        CreatedDate = DateTime.Now,
                        CreatedBy = "khanh.buivuong@nashtechglobal.com",
                        Status = true
                    },
                    new Category()
                    {
                        ID = 9,
                        Name = "Security",
                        Slug = "security",
                        Image = "",
                        CreatedDate = DateTime.Now,
                        CreatedBy = "khanh.buivuong@nashtechglobal.com",
                        Status = true
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
            if (context.SubCategories.Count() == 0)
            {
                List<SubCategory> subCategories = new List<SubCategory>()
                {
                    new SubCategory()
                    {
                        Name = "ASP.NET MVC5",
                        Slug = "asp.net-mvc5",
                        CategoryID = 3,
                        CreatedDate = DateTime.Now,
                        CreatedBy = "khanh.buivuong@nashtechglobal.com",
                        Status = true
                    },
                    new SubCategory()
                    {
                        Name = "ASP.NET MVC Core",
                        Slug = "asp.net-mvc-core",
                        CategoryID = 2,
                        CreatedDate = DateTime.Now,
                        CreatedBy = "khanh.buivuong@nashtechglobal.com",
                        Status = true
                    },
                    new SubCategory()
                    {
                        Name = "ASP.NET Web Form",
                        Slug = "asp.net-web-form",
                        CategoryID = 3,
                        CreatedDate = DateTime.Now,
                        CreatedBy = "khanh.buivuong@nashtechglobal.com",
                        Status = true
                    },
                    new SubCategory()
                    {
                        Name = "NET Windows Form",
                        Slug = "winform",
                        CategoryID = 4,
                        CreatedDate = DateTime.Now,
                        CreatedBy = "khanh.buivuong@nashtechglobal.com",
                        Status = true
                    },
                    new SubCategory()
                    {
                        Name = "Windows Presentation Foundation",
                        Slug = "winform-presentation-foundataion",
                        CategoryID = 4,
                        CreatedDate = DateTime.Now,
                        CreatedBy = "khanh.buivuong@nashtechglobal.com",
                        Status = true
                    },
                    new SubCategory()
                    {
                        Name = "JQuery",
                        Slug = "jquery",
                        CategoryID = 6,
                        CreatedDate = DateTime.Now,
                        CreatedBy = "khanh.buivuong@nashtechglobal.com",
                        Status = true
                    },
                    new SubCategory()
                    {
                        Name = "KnockoutJS",
                        Slug = "knockoutjs",
                        CategoryID = 6,
                        CreatedDate = DateTime.Now,
                        CreatedBy = "khanh.buivuong@nashtechglobal.com",
                        Status = true
                    },
                    new SubCategory()
                    {
                        Name = "Angularjs",
                        Slug = "angularjs",
                        CategoryID = 6,
                        CreatedDate = DateTime.Now,
                        CreatedBy = "khanh.buivuong@nashtechglobal.com",
                        Status = true
                    },
                    new SubCategory()
                    {
                        Name = "Angular 5",
                        Slug = "angular5",
                        CategoryID = 6,
                        CreatedDate = DateTime.Now,
                        CreatedBy = "khanh.buivuong@nashtechglobal.com",
                        Status = true
                    },
                    new SubCategory()
                    {
                        Name = "Reactjs",
                        Slug = "Reactjs",
                        CategoryID = 6,
                        CreatedDate = DateTime.Now,
                        CreatedBy = "khanh.buivuong@nashtechglobal.com",
                        Status = true
                    },
                    new SubCategory()
                    {
                        Name = "Vuejs",
                        Slug = "vuejs",
                        CategoryID = 6,
                        CreatedDate = DateTime.Now,
                        CreatedBy = "khanh.buivuong@nashtechglobal.com",
                        Status = true
                    },
                    new SubCategory()
                    {
                        Name = "My SQL",
                        Slug = "mysql",
                        CategoryID = 8,
                        CreatedDate = DateTime.Now,
                        CreatedBy = "khanh.buivuong@nashtechglobal.com",
                        Status = true
                    },
                    new SubCategory()
                    {
                        Name = "Microsoft SQL Server",
                        Slug = "microsoft-sql-server",
                        CategoryID = 8,
                        CreatedDate = DateTime.Now,
                        CreatedBy = "khanh.buivuong@nashtechglobal.com",
                        Status = true
                    },
                    new SubCategory()
                    {
                        Name = "Oracle",
                        Slug = "oracle",
                        CategoryID = 8,
                        CreatedDate = DateTime.Now,
                        CreatedBy = "khanh.buivuong@nashtechglobal.com",
                        Status = true
                    },
                    new SubCategory()
                    {
                        Name = "Object Oriented Programming",
                        Slug = "oop",
                        CategoryID = 1,
                        CreatedDate = DateTime.Now,
                        CreatedBy = "khanh.buivuong@nashtechglobal.com",
                        Status = true
                    },
                };
                context.SubCategories.AddRange(subCategories);
                context.SaveChanges();
            }
        }
        #endregion

        #region Post Seed Data
        private void PostSeedData(BlogEngineDbContext context)
        {
            if (context.Posts.Count() == 0)
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
                        Status = true,
                        Quote = "Design is not just what is look like, Design is how it's work.",
                        Content = @"
Today we released a prototype of a C# feature called “nullable reference types“, which is intended to help you find and fix most of your null-related bugs before they blow up at runtime.
We would love for you to install the prototype and try it out on your code! (Or maybe a copy of it! 😄) Your feedback is going to help us get the feature exactly right before we officially release it.
The billion-dollar mistake
Tony Hoare, one of the absolute giants of computer science and recipient of the Turing Award, invented the null reference! It’s crazy these days to think that something as foundational and ubiquitous was invented, but there it is. Many years later in a talk, Sir Tony actually apologized, calling it his “billion-dollar mistake”:"
                    },

                    new Post()
                    {
                        Name = ".NET Core 2.1 June Update",
                        Slug = "net-core-2-1-june-update",
                        CategoryID = 2,
                        Summary=@"We released .NET Core 2.1.1. This update includes .NET Core SDK 2.1.301, ASP.NET Core 2.1.1 and .NET Core 2.1.1. See .NET Core 2.1.1 release notes for complete details on the release. Quality Updates CLI [4050c6374] The “pack” command under ‘buildCrossTargeting’ for ‘Microsoft.DotNet.MSBuildSdkResolver’ now throws a “NU5104” warning/error because the SDK stage0 was changed to “2.1.300” [change was",
                        CreatedDate = DateTime.Now,
                        CreatedBy = "khanh.buivuong@nashtechglobal.com",
                        Status = true,
                        Quote = "Because of your smile, you make life more beautiful",
                        Content =@"CLI
                                    [4050c6374] The “pack” command under ‘buildCrossTargeting’ for ‘Microsoft.DotNet.MSBuildSdkResolver’ now throws a “NU5104” warning/error because the SDK stage0 was changed to “2.1.300” [change was intended].
                                    [ea539c7f6] Add retry when Directory.Move (#9313)
                                    CoreCLR
                                    [13ea3c2c8e] Fix alternate stack for Alpine docker on SELinux (#17936) (#17975)
                                    [88db627a97] Update g_highest_address and g_lowest_address in StompWriteBarrier(WriteBarrierOp::StompResize) on ARM (#18107)
                                    [0ea5fc4456] Use sysconf(_SC_NPROCESSORS_CONF) instead of sysconf(_SC_NPROCESSORS_ONLN) in PAL and GC on ARM and ARM64
                                    CoreFX
                                    [3700c5b793] Update to a xUnit Performance Api that has a bigger Etw buffer size. … (#30328)
                                    [6b38470265] Use _SC_NPROCESSORS_CONF instead of _SC_NPROCESSORS_ONLN in Unix_ProcessorCountTest on ARM/ARM64 (#30132)
                                    [fe653a068c] check SwitchingProtocol before ContentLength (#29948) (#29993)
                                    [f11f3e1fcf] Fix handling of cursor position when other ESC sequences already in stdin (#29897) (#29923)
                                    [77a4a19622] [release/2.1] Port nano test fixes (#29995)
                                    [7ce9270ac7] Fix Sockets hang caused by concurrent Socket disposal (#29786) (#29846)
                                    [ed23f5391f] Fix terminfo number reading with 32-bit integers (#29655) (#29765)
                                    [1c34018f14] Fix getting attributes for sharing violation files (#29790) (#29832)
                                    [bc71849976] [release/2.1] Fix deadlock when waiting for process exit in Console.CancelKeyPress (#29749)
                                    [adc1c4d0d5] Fix WebSocket split UTF8 read #29834 (#29840) (#29853)
                                    WCF
                                    [0a99dd88] Add net461 as a supported framework for S.SM.Security.
                                    [45855085] Generate ThisAssembly.cs, update the version and links for svcutil.xmlserializer (#2893)
                                    [68457365] Target svcutil.xmlserializer app at dotnetcore. (#2855)"
                    },
                    new Post()
                    {
                        Name = "JQuery 3.3.1 – Fixed Dependencies In Release Tag",
                        Slug = "jquery-3-3-1–fixed-dependencies-in-release-tag",
                        CategoryID = 6,
                        Summary = @"We encountered an issue in the release for jQuery 3.3.0, so we’ve immediately released another tag. The code itself is identical, but our release dependencies (only used during release) were added to the dependencies of the jQuery package itself due to the new behavior of npm in version 5+.",
                        CreatedDate = DateTime.Now,
                        CreatedBy = "khanh.buivuong@nashtechglobal.com",
                        Status = true,
                        Quote = "Jquery is always awesome ! Cheer",
                        Content = @"We encountered an issue in the release for jQuery 3.3.0, so we’ve immediately released another tag. The code itself is identical, but our release dependencies (only used during release) were added to the dependencies of the jQuery package itself due to the new behavior of npm in version 5+.
                                    jQuery 3.3.1 is now recommended if installing from npm or GitHub. If using jQuery on any CDN, the built file only differs in the version number.
                                    We apologize for any inconvenience and have updated our release script to account for this issue.
                                    Please see the jQuery 3.3.0 blog post for all relevant code changes in this release.
                                    Download
                                    You can get the files from the jQuery CDN, or link to them directly:

                                    https://code.jquery.com/jquery-3.3.1.js

                                    https://code.jquery.com/jquery-3.3.1.min.js

                                    You can also get this release from npm:

                                    npm install jquery@3.3.1

                                    Slim build
                                    Sometimes you don’t need ajax, or you prefer to use one of the many standalone libraries that focus on ajax requests. And often it is simpler to use a combination of CSS and class manipulation for all your web animations. Along with the regular version of jQuery that includes the ajax and effects modules, we’ve released a “slim” version that excludes these modules. The size of jQuery is very rarely a load performance concern these days, but the slim build is about 6k gzipped bytes smaller than the regular version – 24k vs 30k. These files are also available in the npm package and on the CDN:

                                    https://code.jquery.com/jquery-3.3.1.slim.js
                                    https://code.jquery.com/jquery-3.3.1.slim.min.js

                                    These updates are already available as the current versions on npm and Bower. Information on all the ways to get jQuery is available at https://jquery.com/download/. Public CDNs receive their copies today, please give them a few days to post the files. If you’re anxious to get a quick start, use the files on our CDN until they have a chance to update.

                                    8 THOUGHTS ON “JQUERY 3.3.1 – FIXED DEPENDENCIES IN RELEASE TAG”"
                    },
                    new Post()
                    {
                        Name = "Welcome to C# 7.2 and Span",
                        Slug = "welcome-to-c-7-2-and-span",
                        CategoryID = 1,
                        Summary = @"C# 7.2 is the latest point release of C#, and adds a number of small but useful features. All the features are described in wonderful detail in the docs. Start with the overview, What’s new in C# 7.2, which gives you an excellent introduction to the new set of capabilities. It is worth celebrating that",
                        CreatedDate = DateTime.Now,
                        CreatedBy = "khanh.buivuong@nashtechglobal.com",
                        Status = true,
                        Quote = "C# is awesome programming language",
                        Content = @"C# 7.2 is the latest point release of C#, and adds a number of small but useful features.
                                    All the features are described in wonderful detail in the docs. Start with the overview, What’s new in C# 7.2, which gives you an excellent introduction to the new set of capabilities. It is worth celebrating that a significant portion of the docs are community contributed, not least the material on the new private protected access modifier.
                                    The dominant theme of C# 7.2 centers on improving expressiveness around working with structs by reference. This is important in particular for high performance scenarios, where structs help avoid the garbage collection overhead of allocation, whereas struct references help avoid excessive copying.
                                    The docs go into detail on this set of features in Reference semantics with value types, and they are shown in my new “talking head” video on Channel 9, New Features in C# 7.1 and C# 7.2.
                                    Several of these features, while generally useful, were added to C# 7.2 specifically in support of the new Span<T> family of framework types. This library offers a unified (and allocation-free) representation of memory from a multitude of different sources, such as arrays, stack allocation and native code. With its slicing capabilities, it obviates the need for expensive copying and allocation in many scenarios, such as string manipulation, buffer management, etc, and provides a safe alternative to unsafe code. This is really a game changer, in my opinion. While you may start out using it mostly for performance-intensive scenarios, it is lightweight enough that I think many new idioms will evolve for using it in every day code.
                                    Jared Parsons gives a great introduction in his Channel 9 video C# 7.2: Understanding Span. In the December 15 issue of the MSDN Magazine, Stephen Toub will go into even more detail on Span and how to use it.
                                    C# 7.2 ships with the 15.5 release of Visual Studio 2017.
                                    Enjoy C# 7.2 and Span, and happy hacking!
                                    Mads Torgersen, Lead Designer of C#"
                    }
                };
                context.Posts.AddRange(posts);
                context.SaveChanges();
            }
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


